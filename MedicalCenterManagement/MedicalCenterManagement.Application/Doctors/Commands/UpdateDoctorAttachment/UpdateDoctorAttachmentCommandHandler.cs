namespace MedicalCenterManagement.Application.Doctors.Commands.UpdateDoctorAttachment;

public class UpdateDoctorAttachmentCommandHandler(
    IMedicalCenterManagementDbContext context,
    IFileStorageService fileStorageService
) : IHandler<UpdateDoctorAttachmentCommand, Response>
{
    public async Task<Response> Handle(UpdateDoctorAttachmentCommand request)
    {
        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);
        
        if(doctor is null)
            return new NotFoundResponse<Doctor>(ErrorMessages.NotFound<Doctor>());
        
        var attachment = new Attachment(
            path: request.Attachment.Path, 
            type: request.Attachment.Type
        );
        
        doctor.AddAttachment(attachment);
        
        await fileStorageService.UploadAsync(attachment.Path, request.Stream);
        
        await context.SaveChangesAsync();
        
        return new NoContentResponse();
    }
}