using ChurrascApp.Api.Controllers;
using ChurrascApp.Api.Mappers.Event;
using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.Event;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Application.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurrascApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] EventRegisterRequest request)
        {
            var result = await _eventService.Register(request.ToDto());
            var eventResponse = result.ToResponse();

            var response = new ViewResponse<EventResponse>(
                true,
                "Event registered successfully",
                eventResponse
            );

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _eventService.GetById(id);

            var eventResponse = result.ToResponse();

            var response = new ViewResponse<EventResponse>(
                true,
                "Event retrieved successfully",
                eventResponse
            );

            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventService.GetAll();

            var eventResponses = result.Select(e => e.ToResponse()).ToList();

            var response = new ViewResponse<List<EventResponse>>(
                true,
                "Events retrieved successfully",
                eventResponses
            );

            return Ok(response);
        }

        [HttpGet("GetByInviteCode/{inviteCode}")]
        public async Task<IActionResult> GetByInviteCode(string inviteCode)
        {
            var result = await _eventService.GetByInviteCode(inviteCode);

            var eventResponse = result.ToResponse();

            var response = new ViewResponse<EventResponse>(
                true,
                "Event retrieved successfully",
                eventResponse
            );

            return Ok(response);
        }


        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] EventUpdateRequest request)
        {
            var result = await _eventService.Update(request.ToDto());
            var eventResponse = result.ToResponse();

            var response = new ViewResponse<EventResponse>(
                true,
                "Event updated successfully",
                eventResponse
            );

            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _eventService.Delete(id);

            var response = new ViewResponse<bool>(
                true,
                "Event deleted successfully",
                true
            );

            return Ok(response);
        }
    }
}
