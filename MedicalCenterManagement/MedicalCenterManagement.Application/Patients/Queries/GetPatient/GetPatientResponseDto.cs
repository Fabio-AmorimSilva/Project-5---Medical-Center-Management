namespace MedicalCenterManagement.Application.Patients.Queries.GetPatient;

public record GetPatientResponseDto
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Cpf  { get; init; }
    public string Email { get; init; }
}