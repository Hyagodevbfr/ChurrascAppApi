namespace ChurrascApp.Domain.Value_Objects;

public class Location
{
    public string Street { get; set; }
    public int? Number { get; set; }
    public string City { get; set; }
    public int ZipCode { get; set; }

    public Location(string street, int number, string city, int zipCode)
    {
        Validate(street, number, city, zipCode);
        
        Street = street;
        Number = number;
        City = city;    
        ZipCode = zipCode;
    }

    private void Validate(string street, int? number, string city, int zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty");

        if (number < 1)
            throw new ArgumentException("Number cannot be less than 1");
        
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty");
        
        if (city.Length > 15)
            throw new ArgumentException("City cannot be longer than 15 characters");
        
        if (city.Length <= 2)
            throw new ArgumentException("City cannot be longer than 2 characters");

        if (zipCode != 8)
            throw new ArgumentException("Zip Code must be 8 digits");
    }

    public override string ToString()
    {
        return $"{Street},  {Number}, {City}, {ZipCode}";
    }
}