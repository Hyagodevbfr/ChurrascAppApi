
namespace ChurrascApp.Domain.Value_Objects;

public class JoinRequestCode
{
    public string Code { get; set; }
    public JoinRequestCode(string eventId, string userId)
    {
        Validate(eventId, userId);
        Code = eventId + userId;
    }

    private void Validate(string eventId, string userId)
    {
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.", nameof(eventId));
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
    }
}
