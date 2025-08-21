using ChurrascApp.Domain.Value_Objects;

namespace ChurrascApp.Api.Models.Requests;

public class ParticipationRQ
{
    public string UserId { get; set; } = string.Empty;
    public string EventId { get; set; } = string.Empty;
    public List<AssignedItem>? AssignedItems { get; set; }
    public ContributedAmount? ContributedAmount { get; set; }
    public bool? ParticipantInExtraActivity { get; set; }
}
