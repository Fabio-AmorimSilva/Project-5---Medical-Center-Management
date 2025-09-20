namespace MedicalCenterManagement.Domain.Entities;

public class User : Entity
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }
    
    public Doctor? Doctor { get; private set; }
    public Patient? Patient { get; private set; }
    
    private User(){}
    
    public User(
        string email, 
        string password,
        Role role
    )
    {
        Email = email;
        Password = password;
        Role = role;
    }
}