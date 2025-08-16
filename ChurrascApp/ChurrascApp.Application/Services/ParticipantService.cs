using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Application.DTOs.User;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Mappers;
using ChurrascApp.Domain.Repositories;

namespace ChurrascApp.Application.Services;

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;
    public ParticipantService(IParticipantRepository participantRepository)
    {
        _participantRepository = participantRepository;
    }

    // Main Methods
    public async Task<IList<ParticipantResponseDto>> GetConfirmedParticipantsByEventId(string eventId)
    {
        var participants = await _participantRepository.GetConfirmedParticipantsByEventId(eventId);

        return participants.Select(p => p.ToResponse()).ToList();
    }
    public async Task<IList<ParticipantResponseDto>> GetAcceptedAndPendentParticipantsByEventId(string eventId)
    {
        var participants = await _participantRepository.GetAcceptedAndPendentParticipantsByEventId(eventId);

        return participants.Select(p => p.ToResponse()).ToList();
    }
    public async Task<ParticipantResponseDto> GetParticipantByIdFromEvent(string userId, string eventId)
    {
        var participant = await _participantRepository.GetParticipantByIdFromEvent(userId, eventId);

        return participant.ToResponse();
    }
    public async Task<IList<ParticipantResponseDto>> GetParticipantsByEventId(string eventId)
    {
        var participants = await _participantRepository.GetParticipantsByEventId(eventId);

        return participants.Select(p => p.ToResponse()).ToList();
    }
    public async Task<ParticipantResponseDto> SolicitParticipation(ParticipationRequestDto request, string userId, EventResponseDto eventEntity)
    {
        var requestParticipation = await _participantRepository.SolicitParticipation(request, userId, eventEntity);

        return requestParticipation.ToResponse();
    }
    public async Task<ParticipantResponseDto> ConfirmParticipant(string userId, bool isConfirmed)
    {
        var participantConfirmed = await _participantRepository.ConfirmParticipant(userId, isConfirmed);

        return participantConfirmed.ToResponse();
    }
    public async Task<ParticipantResponseDto> CancelParticipation(string userId)
    {
        var participantCanceled = await _participantRepository.CancelParticipation(userId);

        return participantCanceled.ToResponse();
    }
    public async Task<ParticipantResponseDto> ConfirmPayment(string userId)
    {
        var confirmedParticipantPayment = await _participantRepository.ConfirmPayment(userId);

        return confirmedParticipantPayment.ToResponse();
    }
    
    // Generic Methods
    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<ParticipantResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<ParticipantResponseDto> GetById(string id)
    {
        throw new NotImplementedException();
    }
    public Task<ParticipantResponseDto> Register(ParticipantRegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
    public Task<ParticipantResponseDto> Update(ParticipantUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    Task<ParticipantRegisterDto> IParticipantService.ConfirmPayment(string userId)
    {
        throw new NotImplementedException();
    }
}
