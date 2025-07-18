namespace ChurrascApp.Api.Models.Responses;

public class AuthResponse
{
    public string Token { get; private set; }
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
    public string RefreshToken { get; private set; }

    public AuthResponse(string token, bool isSuccess, string message, string refreshToken)
    {
        Token = token;
        IsSuccess = isSuccess;
        Message = message;
        RefreshToken = refreshToken;
    }
}