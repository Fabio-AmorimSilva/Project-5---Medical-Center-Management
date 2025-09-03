namespace MedicalCenterManagement.Domain.Entities;

public class Patient : Entity, IHasIsDeleted
{
    public const int NameMaxLength = 100;
    public const int LastNameMaxLength = 150;
    
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public DateTime Birth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public BloodType BloodType { get; private set; }
    public decimal Height { get; private set; }
    public decimal Weight { get; private set; }
    public Address Address { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public Patient(
        string name, 
        string lastName,
        DateTime birth, 
        string phoneNumber, 
        string email, 
        string cpf, 
        BloodType bloodType, 
        decimal height,
        decimal weight, 
        Address address, 
        bool isDeleted
    )
    {
        Guard.IsNotWhiteSpace(name);
        Guard.IsLessThanOrEqualTo(name.Length, NameMaxLength, nameof(name));
        Guard.IsNotWhiteSpace(lastName);
        Guard.IsLessThanOrEqualTo(lastName.Length, LastNameMaxLength, nameof(lastName));
        Guard.IsNotDefault(birth);
        Guard.IsNullOrWhiteSpace(phoneNumber);
        Guard.IsNotWhiteSpace(email);
        Guard.IsNotWhiteSpace(cpf);
        Guard.IsNotDefault(height);
        Guard.IsNotDefault(weight);
        
        Name = name;
        LastName = lastName;
        Birth = birth;
        PhoneNumber = phoneNumber;
        Email = email;
        Cpf = cpf;
        BloodType = bloodType;
        Height = height;
        Weight = weight;
        Address = address;
        IsDeleted = isDeleted;
    }
}