using ChurrascApp.Application.DTOs.User;
using ChurrascApp.Application.Interfaces.Services;
using ChurrascApp.Domain.Repositories;
using ChurrascApp.Domain.Services;
using ChurrascApp.Application.Mappers;

namespace ChurrascApp.Application.Services;

public class UserService : IUserService
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly PasswordValidationService _passwordValidationService;
    
    public UserService(PasswordValidationService passwordValidationService, IPasswordService passwordService, IUserRepository userRepository, ITokenService tokenService)
    {
        _passwordValidationService = passwordValidationService;
        _passwordService = passwordService;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<UserResponseDto> GetById(string id)
    {
        var user = await _userRepository.GetById(id);

        return user.ToResponse();
    }

    public async Task<IEnumerable<UserResponseDto>> GetAll()
    {
        var users = await _userRepository.GetAll();
        
        return users.Select(u => u.ToResponse()).ToList();
    }

    public async Task<UserResponseDto> Register(UserRegisterDto registerDto)
    {
        var existingEmail = await _userRepository.GetByEmail(registerDto.Email);
        var existingPhoneNumber = await _userRepository.GetByPhoneNumber(registerDto.PhoneNumber);
        var existingCpf = await _userRepository.GetByCpf(registerDto.Cpf);
        
        if (existingEmail != null)
            throw new ArgumentException("Email already exists");
        if (existingPhoneNumber != null)
            throw new ArgumentException("Phone number already exists");
        if (existingCpf != null)
            throw new ArgumentException("Cpf already exists");
        
        _passwordValidationService.Validate(registerDto.Password);
        
        var passwordHashed = _passwordService.HashPassword(registerDto.Password);

        var newUser = registerDto.ToEntity(passwordHashed);

        await _userRepository.Register(newUser);

        return newUser.ToResponse();
    }

    public async Task<UserResponseDto> Update(UserUpdateDto updateDto)
    {
        var user = await _userRepository.GetById(updateDto.Id);
        if (user is null)
            throw new ArgumentException("User not found");

        user.ToUpdate();
        await _userRepository.Update(user);
        
        return user.ToResponse();
    }

    public Task Delete(string id)
    {
        return _userRepository.Delete(id);
    }

    public async Task<UserResponseDto> GetByPhoneNumber(string phoneNumber)
    {
        var user = await _userRepository.GetByPhoneNumber(phoneNumber);
        
        return user.ToResponse();
    }

    public async Task<AuthResponseDto> Login(UserLoginDto userLoginDto)
    {
        var user = await _userRepository.GetByEmail(userLoginDto.Email);
        
        if (user is null)
            throw new ArgumentException("User not found");
        
        var passwordValid = _passwordService.VerifyPassword(user.Password, userLoginDto.Password);
        if (!passwordValid)
            throw new ArgumentException("Invalid password");
        
        var token = _tokenService.GenerateToken(user);

        return new AuthResponseDto(
            token,
            true,
            "Logged in"
        );
    }
}