namespace ChurrascApp.Application.DTOs.User;

public record UserResponseDto(string Id, string FullName, string Cpf, string PhoneNumber, string Email);