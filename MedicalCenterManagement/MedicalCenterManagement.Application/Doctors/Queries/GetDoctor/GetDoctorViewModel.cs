namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctor;

public record GetDoctorViewModel
{
    public string Name { get; init; }
    public string LastName { get; set; }
    public Speciality Speciality { get; set; }
    public string Crm { get; set; }
}