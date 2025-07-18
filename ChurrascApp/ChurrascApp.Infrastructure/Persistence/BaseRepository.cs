using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ChurrascApp.Infrastructure.Persistence;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    private readonly IMongoCollection<T> _mongoContext;

    public BaseRepository(IOptions<MongoDbSettings> services)
    {
        var mongoClient = new MongoClient(services.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(services.Value.DatabaseName);

        _mongoContext = mongoDatabase.GetCollection<T>(typeof(T).Name);
    }
    public async Task<T> GetById(string id)
    {
        try
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _mongoContext.Find(filter).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving the item by public ID: {e.Message}", e);
        }
    }

    public async Task<T> Register(T item)
    {
        try
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
            
            await _mongoContext.InsertOneAsync(item);
            return item;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving the item by public ID: {e.Message}", e);
        }
    }

    public async Task<T> Update(T item)
    {
        try
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, item.Id);

            var updateDefinition = new List<UpdateDefinition<T>>();

            foreach (var property in typeof(T).GetProperties())
            {
                var newValue = property.GetValue(item);

                if (newValue is not null && !(newValue is ValueType && newValue.Equals(0)) && !((newValue is DateTime dt && dt == DateTime.MinValue) || (newValue is TimeSpan ts && ts == TimeSpan.MinValue)))
                {
                    updateDefinition.Add(Builders<T>.Update.Set(property.Name, newValue));
                }
            }

            if (updateDefinition.Count == 0)
                return item;

            var combinedUpdate = Builders<T>.Update.Combine(updateDefinition);

            await _mongoContext.UpdateOneAsync(filter, combinedUpdate);

            return item;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating the item: {e.Message}", e);
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try 
        {
            var result = await _mongoContext.Find(_ => true).ToListAsync();

            return result;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while retrieving all items: {e.Message}", e);
        }
    }

    public async Task Delete(string id)
    {
        try
        {
            var filter = Builders<T>.Filter.Eq(e => e.Id, id);

            await _mongoContext.DeleteOneAsync(filter);
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting the item with public ID {id}: {e.Message}", e);
        }
    }
}