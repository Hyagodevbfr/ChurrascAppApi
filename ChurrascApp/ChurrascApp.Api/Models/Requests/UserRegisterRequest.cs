namespace ChurrascApp.Api.Models.Requests;

public class UserRegisterRequest
{
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public string Cpf{ get; set; }
    public string Email{ get; set; }
    public string PhoneNumber{ get; set; }
    public string Password{ get; set; }
}