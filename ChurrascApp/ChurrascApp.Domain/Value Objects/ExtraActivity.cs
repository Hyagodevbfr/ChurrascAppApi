using ChurrascApp.Domain.Services;

namespace ChurrascApp.Domain.Value_Objects;

public class ExtraActivity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public TotalCost TotalCost { get; private set; }

    public ExtraActivity(string name, string description, TotalCost totalCost)
    {
        var validate = new ValidateEventNameAndDescriptionService();
        
        validate.ValidateEventNameAndDescription(name, description);
        
        Name = name;
        Description = description;
        TotalCost = totalCost;
    }

    
}