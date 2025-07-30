namespace ChurrascApp.Domain.Value_Objects;

public class Contribution
{
    public bool ConfirmedPayment { get; set; }
    public string Item { get; set; } = string.Empty;
}