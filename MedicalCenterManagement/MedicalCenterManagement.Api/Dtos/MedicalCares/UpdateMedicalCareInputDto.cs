namespace MedicalCenterManagement.Api.Dtos.MedicalCares;

public record UpdateMedicalCareInputDto(
    string Insurance,
    DateTime Start,
    DateTime End,
    TypeOfService TypeOfService,
    Guid DoctorId,
    Guid PatientId,
    Guid ServiceId
)
{
    public UpdateMedicalCareCommand AsCommand(Guid medicalCareId)
        => new(
            MedicalCareId: medicalCareId,
            Insurance: Insurance,
            Start: Start,
            End: End,
            TypeOfService: TypeOfService,
            DoctorId: DoctorId,
            PatientId: PatientId,
            ServiceId: ServiceId
        );
}