using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses.Participant;
using ChurrascApp.Application.DTOs.Participant;

namespace ChurrascApp.Api.Mappers;

public static class ParticipantExtensions
{
    public static ParticipantRegisterDto ToDto(this ParticipantRegisterRQ registerRQ)
    {
        return new ParticipantRegisterDto(
            registerRQ.UserId,
            registerRQ.EventId,
            registerRQ.FullName,
            registerRQ.PhoneNumber,
            registerRQ.AssignedItems,
            registerRQ.ContributedAmount,
            registerRQ.ParticipantInExtraActivity
        );
    }

    public static ParticipantRS ToResponse(this ParticipantResponseDto responseDto)
    {
        return new ParticipantRS{
            UserId = responseDto.UserId,
            EventId = responseDto.EventId,
            FullName = responseDto.FullName,
            PhoneNumber =  responseDto.PhoneNumber,
            AssignedItems = responseDto.AssignedItems,
            ContributedAmount = responseDto.ContributedAmount,
            ParticipantInExtraActivity = responseDto.ParticipantInExtraActivity
        };
    }
}
