namespace ChurrascApp.Domain.Value_Objects;

public class RequiredItem
{
    public string Name { get; set; }
    public int RequiredQuantity { get; set; }
    public int AssignedQuantity { get; set; }
    public List<string> AssignedUsers { get; set; }
    
    public RequiredItem(string name, 
                         int requiredQuantity, 
                         int assignedQuantity, 
                         List<string> assignedUsers)
    {
        Name = name;
        RequiredQuantity = requiredQuantity;
        AssignedQuantity = assignedQuantity;
        AssignedUsers = assignedUsers;
    }
}