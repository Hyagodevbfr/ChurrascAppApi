namespace ChurrascApp.Application.DTOs.User;

public record UserUpdateDto(string Id, string FirstName, string LastName, string Cpf, string Email, string Password);