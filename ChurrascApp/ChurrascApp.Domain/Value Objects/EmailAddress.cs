using System.ComponentModel.DataAnnotations;

namespace ChurrascApp.Domain.Value_Objects;

public class EmailAddress
{
    public string Email { get; private set; }

    public EmailAddress(string email)
    {
        if (!IsValid(email))
            throw new ArgumentException("Invalid email address");
        
        Email = email;
    }

    public void ChangeEmail(string newEmail)
    {
        if (!IsValid(newEmail))
            throw new ArgumentException("Invalid email address");
        
        Email = newEmail;
    }
    private static bool IsValid(string email) => !string.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email);
}