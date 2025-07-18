using ChurrascApp.Domain.Value_Objects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChurrascApp.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();
    [BsonElement("personalInfo")]
    public PersonalInfo PersonalInfo { get; private set; }
    [BsonElement("email")]
    public EmailAddress Email { get; private set; }
    [BsonElement("password")]
    public string Password { get; private set; }

    public User(PersonalInfo personalInfo, EmailAddress email, string password)
    {
        PersonalInfo = personalInfo;
        Email = email;
        Password = password;
    }
}