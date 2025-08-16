using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Configurations.Mongo;
using ChurrascApp.Infrastructure.Persistence;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChurrascApp.Infrastructure;

public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
{
    private readonly IMongoCollection<Participant> _mongoContext;
    public ParticipantRepository(IOptions<MongoDbSettings> services, IUserRepository userRepository, IEventRepository eventRepository) : base(services)
    {
        var mongoClient = new MongoClient(services.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(services.Value.DatabaseName);
        _mongoContext = mongoDatabase.GetCollection<Participant>(nameof(Participant));
    }

    public async Task<IList<Participant>> GetConfirmedParticipantsByEventId(string eventId)
    {
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.");

        var filter = Builders<Participant>.Filter.And(
            Builders<Participant>.Filter.Eq(p => p.EventId, eventId),
            Builders<Participant>.Filter.Eq(p => p.Status, StatusParticipant.Confirmed)
        );

        return await _mongoContext.Find(filter).ToListAsync();
    }
    public async Task<IList<Participant>> GetAcceptedAndPendentParticipantsByEventId(string eventId)
    {
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.");

        var filter = Builders<Participant>.Filter.And(
            Builders<Participant>.Filter.Eq(p => p.EventId, eventId),
            Builders<Participant>.Filter.Eq(p => p.Status, StatusParticipant.Accepted | StatusParticipant.Pending)
        );

        return await _mongoContext.Find(filter).ToListAsync();
    }
    public async Task<Participant> GetParticipantByIdFromEvent(string userId, string eventId)
    {
        var filter = Builders<Participant>.Filter.And(
            Builders<Participant>.Filter.Eq(p => p.UserId, userId),
            Builders<Participant>.Filter.Eq(p => p.EventId, eventId)
        );

        return await _mongoContext.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IList<Participant>> GetParticipantsByEventId(string eventId)
    {
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.");

        var filter = Builders<Participant>.Filter.Eq(p => p.EventId, eventId);

        return await _mongoContext.Find(filter).ToListAsync();
    }

    public async Task<Participant> SolicitParticipation(object request, string userId, object eventResponse)
    {
        if (request is not ParticipationRequestDto participationRequest)
            throw new ArgumentException("Invalid request type.");

        if (eventResponse is not EventResponseDto eventRS)
            throw new ArgumentException("Invalid response type");

        ValidateParticipationRequest(participationRequest, eventRS);

        ValidateRequestsValues(participationRequest, eventRS);

        var filterParticipant = Builders<Participant>.Filter.Eq(
                                                    p => p.UserId, userId);

        var participant = await _mongoContext.Find(filterParticipant).
                                                    FirstOrDefaultAsync();

        participant.UpdateStatus(StatusParticipant.Pending);

        await _mongoContext.ReplaceOneAsync(
            Builders<Participant>.Filter.Eq(p => p.Id, participant.Id),
            participant
        );

        return participant;
    }

    public Task<Participant> ConfirmParticipant(string userId, bool isConfirmed)
    {
        var filter = Builders<Participant>.Filter.Eq(p => p.UserId, userId);
        var update = Builders<Participant>.Update.Set(p => p.Status, isConfirmed ? StatusParticipant.Accepted : StatusParticipant.Rejected)
                                                  .Set(p => p.UpdatedStatusAt, DateTime.UtcNow);

        return _mongoContext.FindOneAndUpdateAsync(filter, update);

    }

    public Task<Participant> CancelParticipation(string userId)
    {
        var filter = Builders<Participant>.Filter.Eq(p => p.UserId, userId);
        var update = Builders<Participant>.Update.Set(p => p.Status, StatusParticipant.Cancelled)
                                                  .Set(p => p.UpdatedStatusAt, DateTime.UtcNow);

        return _mongoContext.FindOneAndUpdateAsync(filter, update);
    }
    public async Task<Participant> ConfirmPayment(string userId)
    {
        
        var filter = Builders<Participant>.Filter.Eq(p => p.UserId, userId);
        var update = Builders<Participant>.Update.Set(p => p.ContributedAmount.IsPaid, true)
                                                  .Set(p => p.UpdatedStatusAt, DateTime.UtcNow);

        return await _mongoContext.FindOneAndUpdateAsync(filter, update);
    }


    // Validates the participation request
    private void ValidateParticipationRequest(ParticipationRequestDto request, EventResponseDto eventRS)
    {
        if (eventRS.HasExtraActivities && request.ParticipantInExtraActivity is null)
            throw new ArgumentException("Participant must specify if they will join the extra activity.");

        if (eventRS.HasRequiredItems && request.AssignedItems is null)
            throw new ArgumentException("Participant must specify required items if applicable.");
    }

    public void ValidateRequestsValues(ParticipationRequestDto request, EventResponseDto eventRS)
    {
        if (eventRS.HasExtraActivities && request.ParticipantInExtraActivity is null)
            throw new ArgumentException("Participant must specify if they will join the extra activity.");

        if (eventRS.HasRequiredItems && request.AssignedItems is null)
            throw new ArgumentException("Participant must specify required items if applicable.");
    }

    
}