using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Api.Models.Requests;

public class ParticipantRegisterRQ
{
    public string UserId { get; set; } = string.Empty;
    public string EventId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public List<AssignedItem>? AssignedItems { get; set; }
    public ContributedAmount? ContributedAmount { get; set; }
    public bool? ParticipantInExtraActivity { get; set; }
}
