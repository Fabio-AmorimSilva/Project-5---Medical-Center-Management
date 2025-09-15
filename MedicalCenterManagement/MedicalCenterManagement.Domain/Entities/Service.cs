namespace MedicalCenterManagement.Domain.Entities;

public class Service : Entity, IHasIsDeleted
{
    public const int NameMaxLength = 200;
    public const int DescriptionMaxLength = 1000;
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Period { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    private Service()
    {
    }
    
    public Service(
        string name,
        string description,
        decimal price,
        int period
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        Guard.IsNotWhiteSpace(description);
        Guard.IsLessThanOrEqualTo(description.Length, DescriptionMaxLength, nameof(description));
        Guard.IsNotDefault(price);
        Guard.IsNotDefault(period);
        
        Name = name;
        Description = description;
        Price = price;
        Period = period;
    }

    public void Update(
        string name,
        string description,
        decimal price,
        int period
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        Guard.IsNotWhiteSpace(description);
        Guard.IsLessThanOrEqualTo(description.Length, DescriptionMaxLength, nameof(description));
        Guard.IsNotDefault(price);
        Guard.IsNotDefault(period);
        
        Name = name;
        Description = description;
        Price = price;
        Period = period;
    }
}