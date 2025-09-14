namespace MedicalCenterManagement.Application.Patients.Queries.GetPatient;

public record GetPatientFilterOptions
{
    public Guid? PatientId { get; init; }
    public string? Cpf { get; init; }
    public string? PhoneNumber { get; init; }
    
    public bool HasPatientId() => PatientId.HasValue;
    public bool HasPhoneNumber() => !string.IsNullOrWhiteSpace(PhoneNumber);
    public bool HasCpf() => !string.IsNullOrWhiteSpace(Cpf);
}