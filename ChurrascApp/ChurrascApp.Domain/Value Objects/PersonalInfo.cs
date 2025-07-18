namespace ChurrascApp.Domain.Value_Objects;

public class PersonalInfo
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Cpf Cpf { get; private set; }

    public PersonalInfo(string firstName, string lastName, Cpf cpf)
    {
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Cpf = cpf;
    }
    
    public void ChangeFirstName(string newFirstName)
    {
        FirstName = newFirstName.Trim();
    }

    public void ChangeLastName(string newLastName)
    {
        LastName = newLastName.Trim();
    }
    
    
}