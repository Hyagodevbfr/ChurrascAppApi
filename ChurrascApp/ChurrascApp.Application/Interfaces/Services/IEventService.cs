using ChurrascApp.Application.DTOs.Event;

namespace ChurrascApp.Application.Interfaces.Services;

public interface IEventService : IBaseService<EventResponseDto, EventRegisterDto, EventUpdateDto>
{
    Task<EventResponseDto> GetByInviteCode(string inviteCode);
}
