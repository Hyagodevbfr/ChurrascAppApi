namespace ChurrascApp.Application.DTOs.User;

public record UserRegisterDto(string FirstName, string LastName, string Cpf, string Email, string PhoneNumber, string Password);