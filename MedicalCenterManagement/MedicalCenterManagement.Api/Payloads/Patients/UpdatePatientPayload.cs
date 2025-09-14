namespace MedicalCenterManagement.Api.Payloads.Patients;

public record UpdatePatientPayload(
    decimal Weight,
    decimal Height
)
{
    public UpdatePatientCommand AsCommand(Guid patientId)
        => new(
            PatientId: patientId,
            Weight: Weight,
            Height: Height
        );
}

