
namespace ChurrascApp.Domain.Value_Objects;

public class AssignedItem
{
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public AssignedItem(string name, int quantity)
    {
        Validate(name, quantity);
        Name = name;
        Quantity = quantity;
    }

    private void Validate(string name, int quantity)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Item name cannot be null or empty.", nameof(name));
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
    }
}
