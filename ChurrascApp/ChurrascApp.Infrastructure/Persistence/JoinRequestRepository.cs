using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Configurations.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChurrascApp.Infrastructure.Persistence;

public class JoinRequestRepository : BaseRepository<JoinRequest>, IJoinRequestRepository
{
    private readonly IMongoCollection<JoinRequest> _mongoContext;
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    public JoinRequestRepository(IOptions<MongoDbSettings> services, IEventRepository eventRepository, IUserRepository userRepository) : base(services)
    {
        var mongoClient = new MongoClient(services.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(services.Value.DatabaseName);
        _mongoContext = mongoDatabase.GetCollection<JoinRequest>(nameof(JoinRequest));
        _eventRepository = eventRepository;
        _userRepository = userRepository;
    }

    public async Task<JoinRequest> CreateRequest(JoinRequest item)
    {
        var eventExists = await _eventRepository.GetById(item.EventId);
        var userExists = await _userRepository.GetById(item.UserId);

        if (item.UserId == eventExists?.Organizer.Id)
            throw new InvalidOperationException("Organizer cannot create a join request for their own event.");

        var codeRequest = item.EventId + item.UserId;

        var filter = Builders<JoinRequest>.Filter.Eq(r => r.CodeRequest.Code, codeRequest);

        var request = await _mongoContext.Find(filter).FirstOrDefaultAsync();  
        if (request is not null)
            throw new InvalidOperationException("Join request already exists for this user and event.");

        var joinRequest = new JoinRequest(
            item.UserId,
            item.EventId,
            item.FullName,
            item.PhoneNumber
        );

        await Register(joinRequest);

        return joinRequest;

    }

    public async Task<IList<JoinRequest>> GetAllRequestsByEvent(string eventId)
    {
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.");

        var filter = Builders<JoinRequest>.Filter.Eq(r => r.EventId, eventId);
        return await _mongoContext.Find(filter).ToListAsync();
    }

    public async Task<IList<JoinRequest>> GetAllRequestsByUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("User ID cannot be null or empty.");

        var filter = Builders<JoinRequest>.Filter.Eq(r => r.UserId, userId);
        return await _mongoContext.Find(filter).ToListAsync();
    }

    public async Task<JoinRequest> GetRequestByUser(string eventId, string userId)
    {
        if (string.IsNullOrEmpty(eventId) || string.IsNullOrEmpty(userId))
            throw new ArgumentException("Event ID and User ID cannot be null or empty.");

        var filter = Builders<JoinRequest>.Filter.And(
            Builders<JoinRequest>.Filter.Eq(r => r.EventId, eventId),
            Builders<JoinRequest>.Filter.Eq(r => r.UserId, userId)
        );
        return await _mongoContext.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<JoinRequest> RespondToRequest(string eventId, string userId, bool isAccepted)
    {
        if (string.IsNullOrEmpty(eventId) || string.IsNullOrEmpty(userId))
            throw new ArgumentException("Event ID and User ID cannot be null or empty.");

        var request = await GetRequestByUser(eventId, userId);

        if (request is null)
            throw new InvalidOperationException("Join request not found for the specified user and event.");

        request.Status = isAccepted ? StatusJoinRequest.Authorized : StatusJoinRequest.Rejected;

        var result = await _mongoContext.ReplaceOneAsync(
            r => r.Id == request.Id,
            request
        );
        if (result.ModifiedCount == 0)
            throw new InvalidOperationException("Failed to update the join request status.");

        return request;
    }
}
