using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Application.Interfaces.Services;

namespace ChurrascApp.Application.Global;

public class GlobalServices
{
    private readonly IParticipantService _participantService;
    private readonly IJoinRequestService _joinRequestService;
    public GlobalServices(IParticipantService participantService, IJoinRequestService joinRequestService)
    {
        _participantService = participantService;
        _joinRequestService = joinRequestService;
    }

    public async Task<ParticipantResponseDto> RegisterParticipant(ParticipantRegisterDto registerDto)
    {
        return await _participantService.Register(registerDto);
    }

    public async Task<JoinRQResponseDto> GetJoinRequestByUser(string eventId, string userId)
    {
        return await _joinRequestService.GetRequestByUser(eventId, userId);
    }

    public async Task<JoinRQResponseDto> UpdateJoinRequest(JoinRequestUpdateDto updateDto)
    {
        return await _joinRequestService.Update(updateDto);
    }
}
