using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Application.DTOs.User;

namespace ChurrascApp.Application.Interfaces.Services;

public interface IParticipantService : IBaseService<ParticipantResponseDto, ParticipantRegisterDto, ParticipantUpdateDto>
{
    Task<ParticipantResponseDto> GetParticipantByIdFromEvent(string userId, string eventId);
    Task<IList<ParticipantResponseDto>> GetParticipantsByEventId(string eventId);
    Task<IList<ParticipantResponseDto>> GetConfirmedParticipantsByEventId(string eventId);
    Task<IList<ParticipantResponseDto>> GetAcceptedAndPendentParticipantsByEventId(string eventId);
    Task<ParticipantResponseDto> CancelParticipation(string userId);
    Task<ParticipantResponseDto> SolicitParticipation(ParticipationRequestDto request, string userId, EventResponseDto eventEntity);
    Task<ParticipantResponseDto> ConfirmParticipant(string userId, bool isConfirmed);
    Task<ParticipantRegisterDto> ConfirmPayment(string userId);
}
