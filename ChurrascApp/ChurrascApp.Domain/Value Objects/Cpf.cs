using System.Text.RegularExpressions;

namespace ChurrascApp.Domain.Value_Objects;

public class Cpf
{
    public string Number { get; private set; }

    public Cpf(string cpf)
    {
       if (!IsValid(cpf))
           throw new ArgumentException("Invalid CPF");
       Number = cpf;
    }

    public void ChangeCpf(string newCpf)
    {
        if (!IsValid(newCpf))
            throw new ArgumentException("Invalid CPF");
        Number = newCpf;
    }

    private bool IsValid(string cpf)
    {
        cpf = Regex.Replace(cpf, "[^0-9]", "");
        
        if (cpf.Length != 11)
            return false;
        
        if (cpf.All(c => c == cpf[0]))
            return false;
        
        int[] multiplier1 = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2};
        int[] multiplier2 = new int[] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
        
        string tempCpf = cpf.Substring(9,2);
        int sum = 0;
        
        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
        
        int rest = sum % 11;
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        
        string firstDigit = rest.ToString();
        tempCpf = tempCpf + firstDigit;
        
        sum = 0;
        
        for  (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
        
        rest = sum % 11;
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;
        
        string secondDigit = rest.ToString();
        
        string checkDigit = firstDigit + secondDigit;
        string lastTwoDigits = cpf.Substring(9, 2);

        return lastTwoDigits == checkDigit;

    }
}