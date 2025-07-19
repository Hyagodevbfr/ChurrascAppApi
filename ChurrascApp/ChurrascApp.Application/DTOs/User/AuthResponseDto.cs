namespace ChurrascApp.Application.DTOs.User;

public record AuthResponseDto(string AccessToken, bool IsSuccess, string Message, string RefreshToken);