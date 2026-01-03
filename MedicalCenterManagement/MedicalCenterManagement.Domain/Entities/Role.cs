namespace MedicalCenterManagement.Domain.Entities;

public class Role : Entity
{
    public string Name { get; private set; }

    private Role()
    {
        
    }

    public Role(string name)
    {
        Name = name;
    }
}