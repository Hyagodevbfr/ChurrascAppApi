namespace ChurrascApp.Domain.Value_Objects;

public class ConfirmedGuest
{
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Contribution Contribution { get; set; }
    public bool IsInExtraActivity { get; set; }
}