using System.Data.OleDb;
using ChurrascApp.Api.Mappers;
using ChurrascApp.Api.Mappers.Event;
using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.Event;
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
        private readonly IEventService _eventService;
        public ParticipantController(IParticipantService participantService, IEventService eventService)
        {
            _participantService = participantService;
            _eventService = eventService;
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

        [HttpGet("ConfirmedsByEventId/{id}")]
        public async Task<IActionResult> GetConfirmedParticipantsByEventId(string eventId)
        {
            var result = await _participantService.GetConfirmedParticipantsByEventId(eventId);
            var response = result.Select(p => p.ToResponse()).ToList();

            return Ok(
                new ViewResponse<IList<ParticipantRS>>(
                    true,
                    "Confirmed Participants Retreived Successfully",
                    response
                )
            );
        }
        [HttpPatch("SolicitParticipation")]
        public async Task<IActionResult> SolicitParticipation(ParticipationRQ participation)
        {
            var eventResponse = await _eventService.GetById(participation.EventId);

            var result = await _participantService.SolicitParticipation(participation.ToDto(), participation.UserId, eventResponse);
            var response = result.ToResponse();

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Solicitation Created Successfully.",
                    response
                )
            );
        }

        [HttpPatch("ConfirmParticipant")]
        public async Task<IActionResult> ConfirmParticipant(string userId, bool isConfirmed)
        {
            var result = await _participantService.ConfirmParticipant(userId, isConfirmed);
            var response = result.ToResponse();

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Participant Updated Successfully."
                )
            );
        }

        [HttpPatch("CancelParticipation")]
        public async Task<IActionResult> CancelParticipation(string userId)
        {
            var result = await _participantService.CancelParticipation(userId);
            var response = result.ToResponse();

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Participation Canceled Successfully.",
                    response
                )
            );
        }

        [HttpPatch("ConfirmPayment")]
        public async Task<IActionResult> ConfirmPayment(string userId)
        {
            var result = await _participantService.ConfirmPayment(userId);
            var response = result.ToResponse();

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Participant Payment Confirmed Successfully.",
                    response
                )
            );
        }

        [HttpGet("AcceptedAndPendentByEventId/{eventId}")]
        public async Task<IActionResult> AcceptedAndPendentByEventId(string eventId)
        {
            var result = await _participantService.GetAcceptedAndPendentParticipantsByEventId(eventId);
            var response = result.Select(p => p.ToResponse()).ToList();

            return Ok(
                new ViewResponse<IList<ParticipantRS>>(
                    true,
                    "Accepted and Pendent Participants by Event Id",
                    response
                )
            );
        }

        [HttpGet("GetParticipantByIdFromEvent")]
        public async Task<IActionResult> GetParticipantByIdFromEvent(string userId, string eventId)
        {
            var result = await _participantService.GetParticipantByIdFromEvent(userId, eventId);

            var response = result.ToResponse();

            return Ok(
                new ViewResponse<ParticipantRS>(
                    true,
                    "Participant Retreived Successfully.",
                    response
                )
            );
        }

        [HttpGet("GetParticipantsByEventId/{eventId}")]
        public async Task<IActionResult> GetParticipantsByEventId(string eventId)
        {
            var result = await _participantService.GetParticipantsByEventId(eventId);
            var response = result.Select(p => p.ToResponse()).ToList();

            return Ok(
                new ViewResponse<IList<ParticipantRS>>(
                    true,
                    "Participants Retreived Successfully.",
                    response
                )
            );
        }
    }
}
