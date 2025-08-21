using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Domain.Entities;
using ChurrascApp.Domain.Enums;

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

    public static JoinRequestUpdateDto ToUpdate(this JoinRQResponseDto join)
    {
        return new JoinRequestUpdateDto(
            join.UserId,
            join.EventId,
            join.FullName,
            join.PhoneNumber,
            join.Status,
            join.CodeRequest
        );
    }

    public static JoinRequestUpdateDto ToUpdateStatus(this JoinRQResponseDto join, string statusJoin)
    {
        return new JoinRequestUpdateDto(
            join.UserId,
            join.EventId,
            join.FullName,
            join.PhoneNumber,
            statusJoin,
            join.CodeRequest
        );
    }

    public static JoinRequest ToEntity(this JoinRequestUpdateDto joinUpdate)
    {
        return new JoinRequest(
            joinUpdate.UserId,
            joinUpdate.EventId,
            joinUpdate.FullName,
            joinUpdate.PhoneNumber,
            joinUpdate.CodeRequest
        );
    }

    // Join to Participant
    public static ParticipantRegisterDto ToParticipantRegister(this JoinRequest joinRequest)
    {
        return new ParticipantRegisterDto(
            joinRequest.UserId,
            joinRequest.EventId,
            joinRequest.FullName,
            joinRequest.PhoneNumber
        );
    }
}
