namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctorAttachment;

public class GetDoctorAttachmentQueryHandler(
    IMedicalCenterManagementDbContext context,
    IFileStorageService fileStorageService
) : IHandler<GetDoctorAttachmentQuery, Response<Stream>>
{
    public async Task<Response<Stream>> Handle(GetDoctorAttachmentQuery request)
    {
        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);
        
        if(doctor is null)
            return new NotFoundResponse<Stream>(ErrorMessages.NotFound<Doctor>());
        
        var attachment = doctor.GetAttachment(path: request.Path);
        
        if(attachment is null)
            return new NotFoundResponse<Stream>(ErrorMessages.NotFound<Attachment>());
        
        var stream = await fileStorageService.DownloadAsync(attachment);
        
        return new OkResponse<Stream>(stream);
    }
}