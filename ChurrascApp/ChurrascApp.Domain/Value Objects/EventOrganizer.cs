namespace ChurrascApp.Domain.Value_Objects;

public class EventOrganizer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    
    public EventOrganizer(string id, string name, string number)
    {
        Id = id;
        Name = name;
        Number = number;
    }
}