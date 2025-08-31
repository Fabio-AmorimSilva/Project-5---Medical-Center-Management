namespace MedicalCenterManagement.Domain.Entities;

public class Service : Entity, IHasIsDeleted
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Period { get; private set; }
    public bool IsDeleted { get; set; }

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
        Name = name;
        Description = description;
        Price = price;
        Period = period;
    }
}