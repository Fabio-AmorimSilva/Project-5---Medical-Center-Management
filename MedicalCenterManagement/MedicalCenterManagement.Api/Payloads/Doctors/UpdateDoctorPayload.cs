namespace MedicalCenterManagement.Api.Payloads.Doctors;

public record UpdateDoctorPayload(
    Speciality Speciality,
    string Crm
)
{
    public UpdateDoctorCommand AsCommand(Guid doctorId)
        => new(
            DoctorId: doctorId,
            Speciality: Speciality,
            Crm: Crm
        );
}