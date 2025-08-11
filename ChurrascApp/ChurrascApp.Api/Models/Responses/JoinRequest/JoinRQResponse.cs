namespace ChurrascApp.Api.Models.Responses.JoinRequest;

public class JoinRQResponse
{
    public string UserId { get; set; } = string.Empty;
    public string EventId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime RequestedAt { get; set; }
}
