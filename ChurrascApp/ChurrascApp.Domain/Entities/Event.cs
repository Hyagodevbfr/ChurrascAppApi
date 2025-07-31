using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Value_Objects;


namespace ChurrascApp.Domain.Entities;

public class Event : BaseEntity
{
    public EventBasicInfo BasicInfo { get; private set; }
    public EventOrganizer? Organizer { get; private set; }
    
    public bool HasExtraActivities { get; private set; }
    public ExtraActivity? ExtraActivity { get; private set; }
    
    public bool HasRequiredItems { get; private set; }
    public List<RequiredItem>? RequiredItems { get; private set; }
    
    public ContributionType ContributionType { get; private set; }
    public TotalCost TotalCost { get; private set; }
    
    public InviteCode InviteCode { get; private set; }
    
    public bool LimitedGuests { get; private set; }
    public int? NumberOfGuests { get; private set; }
    
    public List<Guest> InvitedGuests { get; private set; }
    public List<ConfirmedGuest> ConfirmedGuests { get; private set; }
    public Event() { }

    public Event(
        EventBasicInfo basicInfo,
        EventOrganizer organizer,
        bool hasExtraActivities,
        bool hasRequiredItems,
        List<RequiredItem>? requiredItems,
        ExtraActivity? extraActivity,
        ContributionType contributionType,
        TotalCost totalCost,
        bool limitedGuests,
        int? numberOfGuests,
        List<Guest> invitedGuests,
        List<ConfirmedGuest> confirmedGuests
        )
    {
        Validate(limitedGuests, numberOfGuests);

        BasicInfo = basicInfo;
        Organizer = organizer;
        InviteCode = new InviteCode();
        HasExtraActivities = hasExtraActivities;
        ExtraActivity = extraActivity;
        HasRequiredItems = hasRequiredItems;
        RequiredItems = requiredItems;
        ContributionType = contributionType;
        TotalCost = totalCost;
        LimitedGuests = limitedGuests;
        NumberOfGuests = numberOfGuests;
        InvitedGuests = invitedGuests;
        ConfirmedGuests = confirmedGuests;
    }

    private void Validate(bool limitedGuests, int? numberOfGuests)
    {
        if (limitedGuests && numberOfGuests <= 0)
            throw new ArgumentException("Number of guests cannot be zero");
    }
}