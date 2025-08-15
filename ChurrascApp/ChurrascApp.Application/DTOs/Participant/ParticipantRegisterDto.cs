using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.DTOs.Participant;

public record ParticipantRegisterDto(
    string UserId,
    string EventId,
    string FullName,
    string PhoneNumber,
    List<AssignedItem>? AssignedItems = null,
    ContributedAmount? ContributedAmount = null,
    bool? ParticipantInExtraActivity = null
);
