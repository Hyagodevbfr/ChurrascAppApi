using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Domain.Repositories;

public interface IParticipantRepository : IBaseRepository<Participant>
{
    Task<Participant> GetParticipantByIdFromEvent(string userId, string eventId);
    Task<IList<Participant>> GetParticipantsByEventId(string eventId);
    Task<IList<Participant>> GetConfirmedParticipantsByEventId(string eventId);
    Task<IList<Participant>> GetAcceptedAndPendentParticipantsByEventId(string eventId);
    Task<Participant> CancelParticipation(string userId);
    Task<Participant> SolicitParticipation(object request, string userId, object eventEntity);
    Task<Participant> ConfirmParticipant(string userId, bool isConfirmed);
    Task<Participant> ConfirmPayment(string userId);
}
