using ChurrascApp.Domain.Value_Objects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChurrascApp.Domain.Entities;

public class User : BaseEntity
{
    [BsonElement("personalInfo")]
    public PersonalInfo PersonalInfo { get; private set; }
    [BsonElement("contactInfo")]
    public ContactInfo ContactInfo { get; private set; }
    [BsonElement("password")]
    public string Password { get; private set; }

    public User(){}

    public User(PersonalInfo personalInfo, ContactInfo contactInfo, string password)
    {
        PersonalInfo = personalInfo;
        ContactInfo = contactInfo;
        Password = password;
    }
}