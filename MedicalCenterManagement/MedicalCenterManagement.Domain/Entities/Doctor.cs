namespace MedicalCenterManagement.Domain.Entities;

public class Doctor : Entity, IHasIsDeleted
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public DateTime Birth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public BloodType BloodType { get; private set; }
    public Address Address { get; private set; }
    public Speciality Speciality { get; private set; }
    public string Crm { get; private set; }
    public bool IsDeleted { get; set; }

    private Doctor()
    {
    }

    public Doctor(
        string name,
        string lastName,
        DateTime birth,
        string phoneNumber,
        string email,
        string cpf,
        BloodType bloodType,
        Address address,
        Speciality speciality,
        string crm
    )
    {
        Name = name;
        LastName = lastName;
        Birth = birth;
        PhoneNumber = phoneNumber;
        Email = email;
        Cpf = cpf;
        BloodType = bloodType;
        Address = address;
        Speciality = speciality;
        Crm = crm;
    }
}