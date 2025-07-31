namespace ChurrascApp.Domain.Value_Objects;

public class TotalCost
{
    public decimal Value { get; private set; }

    public TotalCost(decimal value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(decimal value)
    {
        if (value <= 0.0m)
            throw new ArgumentException("Value must be greater than zero");
    }

    public override string ToString()
    {
        return $"R${Value:N2}";
    }
}