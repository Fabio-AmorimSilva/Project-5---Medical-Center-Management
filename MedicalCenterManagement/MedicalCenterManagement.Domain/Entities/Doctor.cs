﻿namespace MedicalCenterManagement.Domain.Entities;

public class Doctor : Person, IHasIsDeleted
{
    public Speciality Speciality { get; private set; }
    public string Crm { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    private Doctor()
    {
    }

    public Doctor(
        Speciality speciality,
        string crm,
        string name, 
        string lastName,
        DateTime birth, 
        string phoneNumber, 
        string email, 
        string cpf, 
        BloodType bloodType, 
        Address address
    ) : base(name, lastName, birth, phoneNumber, email, cpf, bloodType, address)
    {
        Guard.IsNotWhiteSpace(crm);
        
        Speciality = speciality;
        Crm = crm;
    }
}