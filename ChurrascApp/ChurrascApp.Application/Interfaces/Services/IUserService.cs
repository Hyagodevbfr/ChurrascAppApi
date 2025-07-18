using ChurrascApp.Application.DTOs.User;

namespace ChurrascApp.Application.Interfaces.Services;

public interface IUserService : IBaseService<UserResponseDto, UserRegisterDto, UserUpdateDto>
{
    Task<UserResponseDto> GetByPhoneNumber(string phoneNumber);
    Task<AuthResponseDto> Login(UserLoginDto userLoginDto);
}