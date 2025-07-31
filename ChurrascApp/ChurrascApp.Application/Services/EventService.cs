using ChurrascApp.Application.DTOs.Event;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Mappers;
using ChurrascApp.Domain.Repositories;

namespace ChurrascApp.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public Task Delete(string id)
    {
        return _eventRepository.Delete(id);
    }

    public async Task<IEnumerable<EventResponseDto>> GetAll()
    {
        var events = await _eventRepository.GetAll();

        return events.Select(e => e.ToResponse()).ToList();
    }

    public async Task<EventResponseDto> GetById(string id)
    {
        var eventEntity = await _eventRepository.GetById(id);

        return eventEntity.ToResponse();
    }

    public async Task<EventResponseDto> GetByInviteCode(string inviteCode)
    {
        var eventEntity = await _eventRepository.GetByInviteCode(inviteCode);

        return eventEntity.ToResponse();
    }

    public async Task<EventResponseDto> Register(EventRegisterDto registerDto)
    {
        var eventEntity = registerDto.ToEntity();

        await _eventRepository.Register(eventEntity);

        return eventEntity.ToResponse();
    }

    public async Task<EventResponseDto> Update(EventUpdateDto updateDto)
    {
        var eventEntity = await _eventRepository.GetById(updateDto.Id);

        if (eventEntity is null)
            throw new ArgumentException("Event not found");

        eventEntity.ToUpdate();

        await _eventRepository.Update(eventEntity);
        
        return eventEntity.ToResponse();
    }
}
