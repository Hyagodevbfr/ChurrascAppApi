namespace ChurrascApp.Application.Interfaces.Services;

public interface IPasswordService
{
    string HashPassword(string rawPassword);
    bool VerifyPassword(string hashedPassword, string rawPassword);
}