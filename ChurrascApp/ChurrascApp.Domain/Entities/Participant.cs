using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Domain.Entities;

public class Participant : BaseEntity
{
    public string UserId { get; private set; } = string.Empty;
    public string EventId { get; private set; } = string.Empty;
    public string FullName { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public List<AssignedItem>? AssignedItems { get; private set; }
    public ContributedAmount? ContributedAmount { get; private set; }
    public bool? ParticipantInExtraActivity { get; set; }
    public StatusParticipant Status { get; private set; }
    public DateTime? UpdatedStatusAt { get; private set; }

    public Participant() { }

    public Participant(string userId,
                       string eventId,
                       string fullName,
                       string phoneNumber,
                       List<AssignedItem>? assignedItems,
                       ContributedAmount? contributedAmount,
                       bool? participantInExtraActivity)
    {
        Validate(userId, eventId, fullName, phoneNumber);

        UserId = userId;
        EventId = eventId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        AssignedItems = assignedItems;
        ContributedAmount = contributedAmount;
        ParticipantInExtraActivity = participantInExtraActivity;
        Status = StatusParticipant.Accepted;
        UpdatedStatusAt = null;
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
    public void UpdateStatus(StatusParticipant status)
    {
        Status = status;
        UpdatedStatusAt = DateTime.UtcNow;
    }
}
