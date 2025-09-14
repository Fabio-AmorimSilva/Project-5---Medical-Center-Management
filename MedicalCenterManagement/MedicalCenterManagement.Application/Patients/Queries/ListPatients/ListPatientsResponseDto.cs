namespace MedicalCenterManagement.Application.Patients.Queries.ListPatients;

public record ListPatientsResponseDto
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Cpf  { get; init; }
    public string Email { get; init; }
}