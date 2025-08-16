using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Application.DTOs.Event;

public class EventResponseDto
{
    public string Id { get; set; }
    public EventBasicInfo BasicInfo { get; set; }
    public EventOrganizer? Organizer { get; set; }

    public bool HasExtraActivities { get; set; }
    public ExtraActivity? ExtraActivity { get; set; }

    public bool HasRequiredItems { get; set; }
    public List<RequiredItem>? RequiredItems { get; set; }

    public ContributionType ContributionType { get; set; }
    public TotalCost TotalCost { get; set; }

    public InviteCode InviteCode { get; set; }

    public bool LimitedGuests { get; set; }
    public int? NumberOfGuests { get; set; }

    public List<Guest> InvitedGuests { get; set; } = new List<Guest>();
    public List<ConfirmedGuest> ConfirmedGuests { get; set; } = new List<ConfirmedGuest>();
    public EventResponseDto(
        string id, EventBasicInfo basicInfo,
        EventOrganizer organizer, bool hasExtraActivities,
        ExtraActivity extraActivity, bool hasRequiredItems,
        List<RequiredItem> requiredItems, ContributionType contributionType,
        TotalCost totalCost, InviteCode inviteCode, bool limitedGuests,
        int? numberOfGuests, List<Guest> invitedGuests, List<ConfirmedGuest> confirmedGuests 
    )
    {
        Id = id;
        BasicInfo = basicInfo;
        Organizer = organizer;
        HasExtraActivities = hasExtraActivities;
        ExtraActivity = extraActivity;
        HasRequiredItems = hasRequiredItems;
        RequiredItems = requiredItems;
        ContributionType = contributionType;
        TotalCost = totalCost;
        InviteCode = inviteCode;
        LimitedGuests = limitedGuests;
        NumberOfGuests = numberOfGuests;
        InvitedGuests = invitedGuests;
        ConfirmedGuests = confirmedGuests;
    }

    public EventResponseDto(EventResponseDto dto)
    {
        Id = dto.Id;
        BasicInfo = dto.BasicInfo;
        Organizer = dto.Organizer;
        HasExtraActivities = dto.HasExtraActivities;
        ExtraActivity = dto.ExtraActivity;
        HasRequiredItems = dto.HasRequiredItems;
        RequiredItems = dto.RequiredItems;
        ContributionType = dto.ContributionType;
        TotalCost = dto.TotalCost;
        InviteCode = dto.InviteCode;
        LimitedGuests = dto.LimitedGuests;
        NumberOfGuests = dto.NumberOfGuests;
        InvitedGuests = dto.InvitedGuests;
        ConfirmedGuests = dto.ConfirmedGuests;
    }
}
