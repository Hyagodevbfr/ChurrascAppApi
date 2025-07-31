using NanoidDotNet;

namespace ChurrascApp.Domain.Value_Objects;

public class InviteCode
{
    public string Code { get; private set; }

    public InviteCode()
    {
        Code = GenerateCode();
    }

    private string GenerateCode()
    {
        var hashCode = Nanoid.Generate(size: 15);
        return $"INV_{hashCode}";
    }
    
}