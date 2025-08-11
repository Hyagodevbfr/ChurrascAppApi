using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Api.Models.Responses.JoinRequest;
using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Api;

public static class JoinRequestExtensions
{
    public static JoinRequest ToResponse(this JoinRQResponse joinRequest)
    {
        return new JoinRequest(
            userId: joinRequest.UserId,
            eventId: joinRequest.EventId,
            fullName: joinRequest.FullName,
            phoneNumber: joinRequest.PhoneNumber
        );
    }

    public static JoinRequestRegisterDto ToDto(this JoinRegisterRequest request)
    {
        return new JoinRequestRegisterDto(
            request.UserId,
            request.EventId,
            request.FullName,
            request.PhoneNumber
        );
    }

    public static JoinRQResponse ToResponse(this JoinRQResponseDto dto)
    {
        return new JoinRQResponse{
            UserId = dto.UserId,
            EventId = dto.EventId,
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            RequestedAt = dto.RequestedAt
        };
    }
}
