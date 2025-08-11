using ChurrascApp.Api;
using ChurrascApp.Api.Controllers;
using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.JoinRequest;
using ChurrascApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinRequestController : BaseController
    {
        private readonly IJoinRequestService _joinRequestService;

        public JoinRequestController(IJoinRequestService joinRequestService)
        {
            _joinRequestService = joinRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] JoinRegisterRequest register)
        {
            var result = await _joinRequestService.Register(register.ToDto())!;

            return Ok(new ViewResponse<JoinRQResponse>(
                true,
                "Join request registered successfully",
                result.ToResponse()
            ));
        }

        [HttpGet("GetRequestByUser")]
        public async Task<IActionResult> GetRequestByUser(string eventId, string userId)
        {
            var result = await _joinRequestService.GetRequestByUser(eventId, userId);

            return Ok(new ViewResponse<JoinRQResponse>(
                true,
                "Join request retrieved successfully",
                result.ToResponse()
            ));
        }

        [HttpGet("GetAllRequestsByEvent")]
        public async Task<IActionResult> GetAllRequestsByEvent(string eventId)
        {
            var result = await _joinRequestService.GetAllRequestsByEvent(eventId);
            var response = result.Select(r => r.ToResponse()).ToList();

            return Ok(new ViewResponse<IList<JoinRQResponse>>(
                true,
                "All join requests for the event retrieved successfully",
                response
            ));
        }

        [HttpGet("GetAllRequestsByUser")]
        public async Task<IActionResult> GetAllRequestsByUser(string userId)
        {
            var result = await _joinRequestService.GetAllRequestsByUser(userId);
            var response = result.Select(r => r.ToResponse()).ToList();

            return Ok(new ViewResponse<IList<JoinRQResponse>>(
                true,
                "All join requests for the user retrieved successfully",
                response
            ));
        }
        
        [HttpPatch("RespondToRequest")]
        public async Task<IActionResult> RespondToRequest(string eventId, string userId, bool isAccepted)
        {
            var result = await _joinRequestService.RespondToRequest(eventId, userId, isAccepted);

            return Ok(new ViewResponse<JoinRQResponse>(
                true,
                "Join request response processed successfully",
                result.ToResponse()
            ));
        }
    }
}
