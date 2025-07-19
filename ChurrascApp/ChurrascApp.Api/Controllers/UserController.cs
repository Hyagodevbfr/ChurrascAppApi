using ChurrascApp.Api.Mappers.User;
using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.User;
using ChurrascApp.Application.DTOs.User;
using ChurrascApp.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurrascApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        //[Authorize]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            var result = await _userService.Register(request.RequestToDto());
                
            var response = new ViewResponse<UserResponse>(
                true,
                "User registered successfully",
                result.DtoToResponse()
            );

            return Ok(response);
        }

        [HttpPost("Login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var result = await _userService.Login(request.LoginToDto());

            var response = new ViewResponse<AuthResponse>(
                true,
                "User logged in successfully",
                result.ToAuthResponse()
            );
            
            return Ok(response);
        }
    }
}
