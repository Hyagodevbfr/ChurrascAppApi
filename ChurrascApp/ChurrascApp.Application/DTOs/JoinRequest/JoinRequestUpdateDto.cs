namespace ChurrascApp.Application.DTOs.JoinRequest;

public record JoinRequestUpdateDto(
    string UserId,
    string EventId,
    string FullName,
    string PhoneNumber,
    string Status,
    string CodeRequest
);