using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.DTOs.Participant;

public record ParticipantResponseDto(
    string UserId,
    string EventId,
    string FullName,
    string PhoneNumber,
    List<AssignedItem>? AssignedItems = null,
    ContributedAmount? ContributedAmount = null,
    bool? ParticipantInExtraActivity = null,
    StatusParticipant Status = StatusParticipant.Accepted,
    DateTime? UpdatedStatusAt = null
);
