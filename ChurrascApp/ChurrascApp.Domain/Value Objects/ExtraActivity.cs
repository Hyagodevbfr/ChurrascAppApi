namespace ChurrascApp.Domain.Value_Objects;

public class ExtraActivity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
}