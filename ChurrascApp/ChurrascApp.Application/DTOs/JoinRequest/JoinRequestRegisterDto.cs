namespace ChurrascApp.Application.DTOs.JoinRequest;

public record JoinRequestRegisterDto(
    string UserId,
    string EventId,
    string FullName,
    string PhoneNumber
);
