namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctorAttachment;

public record GetDoctorAttachmentQuery(
    Guid DoctorId,
    string Path
) : IRequest<Response<Stream>>;