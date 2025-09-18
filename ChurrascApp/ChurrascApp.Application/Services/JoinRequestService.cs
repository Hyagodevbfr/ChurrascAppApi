using ChurrascApp.Application.DTOs.JoinRequest;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChurrascApp.Application.Services;

public class JoinRequestService : IJoinRequestService
{
    private readonly IJoinRequestRepository _joinRequestRepository;
    private readonly IServiceProvider _serviceProvider;

    public JoinRequestService(IJoinRequestRepository joinRequestRepository, IServiceProvider serviceProvider)
    {
        _joinRequestRepository = joinRequestRepository;
        _serviceProvider = serviceProvider;
    }

    private IParticipantService GetParticipantService()
    {
        return _serviceProvider.GetRequiredService<IParticipantService>();
    }

    public Task Delete(string id)
    {
        return _joinRequestRepository.Delete(id);
    }

    public Task<IEnumerable<JoinRQResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<JoinRQResponseDto>> GetAllRequestsByEvent(string eventId)
    {
        var requests = await _joinRequestRepository.GetAllRequestsByEvent(eventId);

        return requests.Select(r => r.ToResponse()).ToList();
    }

    public async Task<IList<JoinRQResponseDto>> GetAllRequestsByUser(string userId)
    {
        var requests = await _joinRequestRepository.GetAllRequestsByUser(userId);

        return requests.Select(r => r.ToResponse()).ToList();
    }

    public Task<JoinRQResponseDto> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<JoinRQResponseDto> GetRequestByUser(string eventId, string userId)
    {
        var request = await _joinRequestRepository.GetRequestByUser(eventId, userId);

        return request.ToResponse();
    }

    public async Task<JoinRQResponseDto> Register(JoinRequestRegisterDto registerDto)
    {
        var joinRequest = registerDto.ToEntity();
        await _joinRequestRepository.CreateRequest(joinRequest);

        return joinRequest.ToResponse();
    }

    public async Task<JoinRQResponseDto> RespondToRequest(string eventId, string userId, bool isAccepted)
    {
        var request = await _joinRequestRepository.RespondToRequest(eventId, userId, isAccepted);
        var participantService = GetParticipantService();

        var joinToParticipant = request.ToParticipantRegister();
        await participantService.Register(joinToParticipant);
        
        return request.ToResponse();
    }

    public async Task<JoinRQResponseDto> Update(JoinRequestUpdateDto updateDto)
    {
        var request = await _joinRequestRepository.Update(updateDto.ToEntity());
        
        return request.ToResponse();
    }
}
