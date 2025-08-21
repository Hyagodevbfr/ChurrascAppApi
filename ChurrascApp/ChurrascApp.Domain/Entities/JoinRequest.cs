using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Domain.Entities;

public class JoinRequest : BaseEntity
{
    public string UserId { get; set; }
    public string EventId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public StatusJoinRequest Status { get; set; }
    public JoinRequestCode CodeRequest { get; set; }
    public DateTime RequestedAt { get; set; }

    public JoinRequest() { }

    public JoinRequest(string userId, string eventId, string fullName, string phoneNumber, string? codeRequest = null)
    {
        Validate(userId, eventId, fullName, phoneNumber);

        UserId = userId;
        EventId = eventId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Status = StatusJoinRequest.Pending;

        if (string.IsNullOrEmpty(codeRequest))
            CodeRequest = new JoinRequestCode(eventId, userId);
        else
            CodeRequest!.Code = codeRequest;

        RequestedAt = DateTime.UtcNow;
    }

    private void Validate(string userId, string eventId, string fullName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
        if (string.IsNullOrEmpty(eventId))
            throw new ArgumentException("Event ID cannot be null or empty.", nameof(eventId));
        if (string.IsNullOrEmpty(fullName))
            throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
        if (string.IsNullOrEmpty(phoneNumber))
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
    }
}
