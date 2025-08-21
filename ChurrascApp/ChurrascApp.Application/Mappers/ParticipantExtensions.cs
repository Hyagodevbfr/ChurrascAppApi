using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Application.Mappers;

public static class ParticipantExtensions
{
    public static ParticipantResponseDto ToResponse(this Participant participant)
    {
        return new ParticipantResponseDto(
            participant.UserId,
            participant.EventId,
            participant.FullName,
            participant.PhoneNumber,
            participant.AssignedItems,
            participant.ContributedAmount,
            participant.ParticipantInExtraActivity,
            participant.Status,
            participant.UpdatedStatusAt
        );
    }

    public static Participant ToEntity(this ParticipantResponseDto responseDto)
    {
        return new Participant(
            responseDto.UserId,
            responseDto.EventId,
            responseDto.FullName,
            responseDto.PhoneNumber,
            responseDto.AssignedItems,
            responseDto.ContributedAmount,
            responseDto.ParticipantInExtraActivity
        );
    }

    public static Participant ToEntity(this ParticipantRegisterDto registerDto)
    {
        return new Participant(
            registerDto.UserId,
            registerDto.EventId,
            registerDto.FullName,
            registerDto.PhoneNumber,
            registerDto.AssignedItems,
            registerDto.ContributedAmount,
            registerDto.ParticipantInExtraActivity
        );
    }

    //Participant toJoinRequest
}


