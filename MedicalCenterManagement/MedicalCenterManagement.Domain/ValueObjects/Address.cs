namespace MedicalCenterManagement.Domain.ValueObjects;

public class Address : ValueObject
{
    public string PublicArea { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; set; }

    public Address(
        string publicArea,
        string city,
        string state,
        string country,
        string zipCode
    )
    {
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