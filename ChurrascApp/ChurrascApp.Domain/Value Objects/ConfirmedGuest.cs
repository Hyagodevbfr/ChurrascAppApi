namespace ChurrascApp.Domain.Value_Objects;

public class ConfirmedGuest
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Contribution Contribution { get; set; }
    public bool IsInExtraActivity { get; set; }

    public ConfirmedGuest(string userId, string name, string phoneNumber, Contribution contribution, bool isInExtraActivity)
    {
        UserId = userId;
        Name = name;
        PhoneNumber = phoneNumber;
        Contribution = contribution;
        IsInExtraActivity = isInExtraActivity;
    }
}