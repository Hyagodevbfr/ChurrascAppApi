using ChurrascApp.Domain;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Configurations.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChurrascApp.Infrastructure.Persistence;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    private readonly IMongoCollection<Event> _mongoContext;

    public EventRepository(IOptions<MongoDbSettings> eventService) : base(eventService)
    {
        var mongoClient = new MongoClient(eventService.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(eventService.Value.DatabaseName);
        _mongoContext = mongoDatabase.GetCollection<Event>(nameof(Event));
    }

    public Task<Event> GetByInviteCode(string inviteCode)
    {
        var filter = Builders<Event>.Filter.Eq(e => e.InviteCode.Code, inviteCode);

        var eventEntity = _mongoContext.Find(filter).FirstOrDefaultAsync();
        return eventEntity;

    }
}