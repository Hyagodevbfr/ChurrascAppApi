using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.DTOs.Participant;

public record ParticipationRequestDto(
    string UserId,
    string EventId,
    List<AssignedItem>? AssignedItems = null,
    ContributedAmount? ContributedAmount = null,
    bool? ParticipantInExtraActivity = null
);