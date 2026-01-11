namespace MedicalCenterManagement.Application.Patients.Queries.GetPatientAttachment;

public record GetPatientAttachmentQuery(
    Guid PatientId,
    string Path
) : IRequest<Response<Stream>>;