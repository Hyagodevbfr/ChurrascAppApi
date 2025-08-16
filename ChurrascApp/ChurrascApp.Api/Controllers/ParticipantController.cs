using ChurrascApp.Api.Mappers;
using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.Participant;
using ChurrascApp.Application.DTOs.Participant;
using ChurrascApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurrascApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : BaseController
    {
        private readonly IParticipantService _participantService;
        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(ParticipantRegisterRQ register)
        {
            var result = await _participantService.Register(register.ToDto());

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Participant registered Successfully",
                    result.ToResponse()
                )
            );
        }
    }
}
