using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;


namespace ChurrascApp.Domain.Entities;

public class Event : BaseEntity
{

    public DateTime DateAndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public EventOrganizer Organizer { get; set; } = new();
    public ContributionType ContributionType { get; set; }
    public ExtraActivity? ExtraActivity { get; set; }
    public List<RequiredItem>? RequiredItems { get; set; }
    public decimal TotalCost { get; set; }
    public string InviteCode { get; set; }  = string.Empty;
    public bool LimitedGuests { get; set; }
    public int NumberOfGuests { get; set; }
    public List<Guest> InvitedGuests { get; set; } = new();
    public List<ConfirmedGuest> ConfirmedGuests { get; set; }

}