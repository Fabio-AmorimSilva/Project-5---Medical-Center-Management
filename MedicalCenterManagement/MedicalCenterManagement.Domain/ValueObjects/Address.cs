namespace MedicalCenterManagement.Domain.ValueObjects;

public class Address : ValueObject
{
    public string PublicArea { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }

    public Address(
        string publicArea,
        string city,
        string state,
        string country,
        string zipCode
    )
    {
        Guard.IsNotWhiteSpace(publicArea);
        Guard.IsNotWhiteSpace(city);
        Guard.IsNotWhiteSpace(state);
        Guard.IsNotWhiteSpace(country);
        Guard.IsNotWhiteSpace(zipCode);
        
        PublicArea = publicArea;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PublicArea;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
    }
}