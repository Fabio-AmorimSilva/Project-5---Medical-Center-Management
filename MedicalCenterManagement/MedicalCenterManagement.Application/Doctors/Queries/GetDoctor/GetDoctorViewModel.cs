namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctor;

public record GetDoctorViewModel
{
    public string Name { get; init; } = null!;
    public string LastName { get; set; } = null!;
    public Speciality Speciality { get; set; }
    public string Crm { get; set; } = null!;
}