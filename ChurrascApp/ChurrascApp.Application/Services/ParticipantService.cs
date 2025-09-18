using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Application.DTOs.User;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Mappers;
using ChurrascApp.Domain.Enums;
using ChurrascApp.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChurrascApp.Application.Services;

public class ParticipantService : IParticipantService
{
    private readonly IParticipantRepository _participantRepository;
    private readonly IServiceProvider _serviceProvider;
    public ParticipantService(IParticipantRepository participantRepository, IServiceProvider serviceProvider)
    {
        _participantRepository = participantRepository;
        _serviceProvider = serviceProvider;
    }

    private IJoinRequestService GetJoinRequestService()
    {
        return _serviceProvider.GetRequiredService<IJoinRequestService>();
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
        var joinRequestService = GetJoinRequestService();
        var requestParticipation = await _participantRepository.SolicitParticipation(request, userId, eventEntity);
        var join = await joinRequestService.GetRequestByUser(request.EventId, userId);
        var joinUpdate = join.ToUpdateStatus(StatusJoinRequest.Pending.ToString());

        return requestParticipation.ToResponse();
    }
    public async Task<ParticipantResponseDto> ConfirmParticipant(string userId, bool isConfirmed)
    {
        var joinRequestService = GetJoinRequestService();
        var participant = await _participantRepository.ConfirmParticipant(userId, isConfirmed);

        var join = await joinRequestService.GetRequestByUser(participant.EventId, userId);
        var joinUpdate = join.ToUpdateStatus(participant.Status.ToString());

        await joinRequestService.Update(joinUpdate);


        return participant.ToResponse();
    }
    public async Task<ParticipantResponseDto> CancelParticipation(string userId)
    {
        var joinRequestService = GetJoinRequestService();
        var participant = await _participantRepository.CancelParticipation(userId);

        var join = await joinRequestService.GetRequestByUser(participant.EventId, userId);
        var joinUpdate = join.ToUpdateStatus(StatusJoinRequest.Rejected.ToString());

        await joinRequestService.Update(joinUpdate);

        return participant.ToResponse();
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
    public async Task<ParticipantResponseDto> Register(ParticipantRegisterDto registerDto)
    {
        var result = await _participantRepository.Register(registerDto.ToEntity());

        return result.ToResponse();
    }
    public Task<ParticipantResponseDto> Update(ParticipantUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}
