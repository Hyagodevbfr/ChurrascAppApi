namespace ChurrascApp.Api.Models.Requests;

public class UserRegisterRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName{ get; set; } = string.Empty;
    public string Cpf{ get; set; } = string.Empty;
    public string Email{ get; set; } = string.Empty;
    public string PhoneNumber{ get; set; } = string.Empty;
    public string Password{ get; set; } = string.Empty;
}