namespace ChurrascApp.Domain.Value_Objects;

public class RequiredItem
{
    public string Name { get; set; } =string.Empty;
    public int RequiredQuantity { get; set; }
    public int AssignedQuantity { get; set; }
    public List<string> AssignedUsers { get; set; }
}