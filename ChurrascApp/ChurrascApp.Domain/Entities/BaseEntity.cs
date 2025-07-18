using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChurrascApp.Domain.Entities;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();
}