namespace ChurrascApp.Domain.Services;

public class ValidateEventNameAndDescriptionService
{
    public void ValidateEventNameAndDescription(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty");
        
        if (name.Length > 100)
            throw new ArgumentException("Name cannot be longer than 100 characters");
        
        if (description.Length > 400)
            throw new ArgumentException("Description cannot be longer than 400 characters");
    }
}