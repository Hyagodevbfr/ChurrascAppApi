namespace ChurrascApp.Application.Configurations.Token;

public class TokenConfiguration
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    public int TimeToExpiry { get; set; }
}