using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Api.Models.Responses.Event;

public class EventResponse
{
    public string Id { get; set; }
    public EventBasicInfo BasicInfo { get; set; }
    public EventOrganizer Organizer { get; set; }
    public bool HasExtraActivities { get; set; }
    public ExtraActivity ExtraActivity { get; set; }
    public bool HasRequiredItems { get; set; }
    public List<RequiredItem> RequiredItems { get; set; }
    public ContributionType ContributionType { get; set; }
    public TotalCost TotalCost { get; set; }
    public InviteCode InviteCode { get; set; }
    public bool LimitedGuests { get; set; }
    public int? NumberOfGuests { get; set; }
    public List<Guest> InvitedGuests { get; set; }
    public List<ConfirmedGuest> ConfirmedGuests { get; set; }
}