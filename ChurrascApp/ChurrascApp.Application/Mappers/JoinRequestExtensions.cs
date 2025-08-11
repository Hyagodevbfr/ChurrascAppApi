using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Application;

public static class JoinRequestExtensions
{
    public static JoinRQResponseDto ToResponse(this JoinRequest joinRequest)
    {
        return new JoinRQResponseDto(
            joinRequest.UserId,
            joinRequest.EventId,
            joinRequest.FullName,
            joinRequest.PhoneNumber,
            joinRequest.Status.ToString(),
            joinRequest.CodeRequest.Code,
            joinRequest.RequestedAt
        );
    }

    public static JoinRequest ToEntity(this JoinRequestRegisterDto registerDto)
    {
        return new JoinRequest(
            registerDto.UserId,
            registerDto.EventId,
            registerDto.FullName,
            registerDto.PhoneNumber
        );
    }
}
