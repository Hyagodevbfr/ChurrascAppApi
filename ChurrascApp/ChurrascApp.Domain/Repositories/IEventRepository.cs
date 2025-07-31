using ChurrascApp.Domain.Entities;

namespace ChurrascApp.Domain.Repositories;

public interface IEventRepository : IBaseRepository<Event>
{
    Task<Event> GetByInviteCode(string inviteCode);
}
