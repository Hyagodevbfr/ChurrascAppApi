namespace ChurrascApp.Domain.Value_Objects;

public class Guest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Guest(string id, string name, string phoneNumber)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
    }
}