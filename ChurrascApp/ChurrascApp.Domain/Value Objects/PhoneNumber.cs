using System.Text.RegularExpressions;

namespace ChurrascApp.Domain.Value_Objects;

public class PhoneNumber
{
    public string Number { get; private set; }

    public PhoneNumber(string number)
    {
        if (!IsValid(number))
            throw new ArgumentException("Invalid phone number");
        Number = number;
    }

    public void ChangeNumber(string number)
    {
        if (!IsValid(number))
            throw new ArgumentException("Invalid phone number");
        Number = number;
    }

    private bool IsValid(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return false;
        
        number = Regex.Replace(number, "[^0-9]", "");
        
        if (number.Length < 10 || number.Length > 11)
            return false;
        
        if (number.All(c => c == number[0]))
            return false;

        return Regex.IsMatch(number, @"^(1[1-9]|[2-9][0-9])(9[0-9]{8}|[0-9]{8})$");
    }
}