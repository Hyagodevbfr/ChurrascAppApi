namespace ChurrascApp.Domain.Services;

public class PasswordValidationService
{
    public void Validate(string password)
    {
        if(string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password user is null or empty");
            
        if(password.Length < 8)
            throw new ArgumentException("Password must contain at least 8 characters");

        bool hasSpecialChar = false;

        foreach (char c in password)
        {
            if (!char.IsLetterOrDigit(c))
            {
                hasSpecialChar = true;
                break;
            }
        }
        
        if (!hasSpecialChar)
            throw new ArgumentException("Password must contain at least one special character");
    }
}