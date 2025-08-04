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

    }
}
