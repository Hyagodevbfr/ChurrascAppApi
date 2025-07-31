using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.DTOs.Event;

public record EventUpdateDto(
    string Id, 
    EventBasicInfo BasicInfo,
    EventOrganizer? Organizer,
    bool HasExtraActivities,
    ExtraActivity? ExtraActivity,
    bool HasRequiredItems,
    List<RequiredItem>? RequiredItems,
    ContributionType ContributionType,
    TotalCost TotalCost,
    InviteCode InviteCode,
    bool LimitedGuests,
    int? NumberOfGuests,
    List<Guest> InvitedGuests,
    List<ConfirmedGuest> ConfirmedGuests
);
