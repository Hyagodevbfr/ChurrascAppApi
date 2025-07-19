using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Infrastructure.Configurations.Mongo;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    
    public User Users {get; set; } 
}