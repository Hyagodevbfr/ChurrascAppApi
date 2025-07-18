using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChurrascApp.Infrastructure.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly IMongoCollection<User> _mongoContext;
    
    public UserRepository(IOptions<MongoDbSettings> userService) : base(userService)
    {
        var mongoClient = new MongoClient(userService.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(userService.Value.DatabaseName);
        _mongoContext = mongoDatabase.GetCollection<User>(nameof(User));
    }

    public Task<User> GetByEmail(string email)
    {
        var filter = Builders<User>.Filter.Eq(u => u.ContactInfo.EmailAddress.Email, email);
        var user = _mongoContext.Find(filter).FirstOrDefaultAsync();
        return user;
    }

    public Task<User> GetByCpf(string cpf)
    {
        var filter = Builders<User>.Filter.Eq(u => u.PersonalInfo.Cpf.Number, cpf);
        var user = _mongoContext.Find(filter).FirstOrDefaultAsync();
        
        return user;
    }

    public Task<User> GetByPhoneNumber(string phoneNumber)
    {
        var filter = Builders<User>.Filter.Eq(u => u.ContactInfo.PhoneNumber.Number, phoneNumber);
        var user = _mongoContext.Find(filter).FirstOrDefaultAsync();
        
        return user;
    }
}