using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Domain.Repositories;

public interface IJoinRequestRepository : IBaseRepository<JoinRequest>
{
    Task<JoinRequest> CreateRequest(JoinRequest item);
    Task<JoinRequest> GetRequestByUser(string eventId, string userId);
    Task<IList<JoinRequest>> GetAllRequestsByEvent(string eventId);
    Task<IList<JoinRequest>> GetAllRequestsByUser(string userId);
    Task<JoinRequest> RespondToRequest(string eventId, string userId, bool isAccepted);
}
