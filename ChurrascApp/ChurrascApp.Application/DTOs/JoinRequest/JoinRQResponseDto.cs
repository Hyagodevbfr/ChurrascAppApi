namespace ChurrascApp.Application.DTOs.JoinRequest;

public record JoinRQResponseDto(
    string UserId,
    string EventId,
    string FullName,
    string PhoneNumber,
    string Status,
    string CodeRequest,
    DateTime RequestedAt
);
