using ChurrascApp.Api.Models.Requests;
using ChurrascApp.Api.Models.Responses;
using ChurrascApp.Api.Models.Responses.User;
using ChurrascApp.Application.DTOs.User;

namespace ChurrascApp.Api.Mappers.User;

public static class UserExtensions
{
    //Login Extensions
    public static UserLoginRequest LoginToRequest(this UserLoginDto loginDto)
    {
        return new UserLoginRequest { Email = loginDto.Email, Password = loginDto.Password };
    }

    public static UserLoginDto LoginToDto(this UserLoginRequest loginRequest)
    {
        return new UserLoginDto(loginRequest.Email, loginRequest.Password);
    }

    public static AuthResponse ToAuthResponse(this AuthResponseDto authResponseDto)
    {
        return new AuthResponse(
            authResponseDto.AccessToken,
            authResponseDto.IsSuccess,
            authResponseDto.Message,
            authResponseDto.RefreshToken
            );
    }
    
    //Register Extensions
    public static UserRegisterRequest DtoToRequest(this UserRegisterDto registerDto)
    {
        return new UserRegisterRequest
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Cpf = registerDto.Cpf,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            Password = registerDto.Password
        };
    }

    public static UserRegisterDto RequestToDto(this UserRegisterRequest registerRequest)
    {
        return new UserRegisterDto(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Cpf,
            registerRequest.Email,
            registerRequest.PhoneNumber,
            registerRequest.Password
        );
    }

    public static UserResponse RequestToResponse(this UserRegisterRequest userRegisterRequest, string id)
    {
        return new UserResponse
        {
            Id = id,
            FullName = $"{userRegisterRequest.FirstName}  {userRegisterRequest.LastName}",
            Email = userRegisterRequest.Email,
            PhoneNumber = userRegisterRequest.PhoneNumber,
            Cpf = userRegisterRequest.Cpf
        };
    }

    public static UserResponse DtoToResponse(this UserResponseDto  userResponseDto)
    {
        return new UserResponse
        {
            Id = userResponseDto.Id,
            FullName = userResponseDto.FullName,
            Email = userResponseDto.Email,
            PhoneNumber = userResponseDto.PhoneNumber,
            Cpf = userResponseDto.Cpf
        };
    }
    
    //Update Extensions
    public static UserUpdateRequest DtoToRequest(this UserUpdateDto updateDto)
    {
        return new UserUpdateRequest
        {
            Id = updateDto.Id,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Cpf = updateDto.Cpf,
            Email = updateDto.Email,
            PhoneNumber = updateDto.PhoneNumber,
            Password = updateDto.Password
        };
    }

    public static UserUpdateDto RequestToDto(this UserUpdateRequest updateRequest)
    {
        return new UserUpdateDto(
            updateRequest.Id,
            updateRequest.FirstName,
            updateRequest.LastName,
            updateRequest.Cpf,
            updateRequest.Email,
            updateRequest.PhoneNumber,
            updateRequest.Password
        );
    }

    public static UserResponse RequestToResponse(this UserUpdateRequest updateRequest)
    {
        return new UserResponse
        {
            Id = updateRequest.Id,
            FullName = $"{updateRequest.FirstName}  {updateRequest.LastName}",
            Cpf = updateRequest.Cpf,
            Email = updateRequest.Email,
            PhoneNumber = updateRequest.PhoneNumber,
        };
    }
}