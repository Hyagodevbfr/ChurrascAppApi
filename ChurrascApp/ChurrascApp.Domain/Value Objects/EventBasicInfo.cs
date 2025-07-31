using ChurrascApp.Domain.Services;

namespace ChurrascApp.Domain.Value_Objects;

public class EventBasicInfo
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public DateAndTime DateAndTime { get; private set; }
    public Location EventLocation { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public EventBasicInfo(string name, string description, DateAndTime dateAndTime, Location eventLocation)
    {
        var validate = new ValidateEventNameAndDescriptionService();
        
        validate.ValidateEventNameAndDescription(name, description);
        
        Name = name;
        Description = description;
        DateAndTime = dateAndTime;
        EventLocation = eventLocation;
        CreatedAt = DateTime.Now;
    }
}