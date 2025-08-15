namespace ChurrascApp.Domain.Value_Objects;

public class ContributedAmount
{
    public decimal Value { get; private set; }
    public bool IsPaid { get; private set; }
    public ContributedAmount(decimal value, bool isPaid)
    {
        if (value < 0)
            throw new ArgumentException("Contributed amount cannot be negative.", nameof(value));

        Value = value;
        IsPaid = isPaid;
    }
    
    public void MarkAsPaid()
    {
        IsPaid = true;
    }

}
