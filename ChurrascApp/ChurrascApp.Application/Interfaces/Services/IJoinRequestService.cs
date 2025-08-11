using ChurrascApp.Application.DTOs.JoinRequest;

namespace ChurrascApp.Application.Interfaces.Services;

public interface IJoinRequestService : IBaseService<JoinRQResponseDto, JoinRequestRegisterDto, JoinRequestUpdateDto>
{
    Task<JoinRQResponseDto> GetRequestByUser(string eventId, string userId);
    Task<IList<JoinRQResponseDto>> GetAllRequestsByEvent(string eventId);
    Task<IList<JoinRQResponseDto>> GetAllRequestsByUser(string userId);
    Task<JoinRQResponseDto> RespondToRequest(string eventId, string userId, bool isAccepted);
}