namespace ChurrascApp.Domain.Value_Objects;

public class ContactInfo
{
    public EmailAddress EmailAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    public ContactInfo(EmailAddress emailAddress, PhoneNumber phoneNumber)
    {
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
    }
}