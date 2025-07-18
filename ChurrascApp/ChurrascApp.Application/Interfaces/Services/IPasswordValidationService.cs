namespace ChurrascApp.Application.Interfaces.Services;

public interface IPasswordValidationService
{
    Task Validate(string password);
}