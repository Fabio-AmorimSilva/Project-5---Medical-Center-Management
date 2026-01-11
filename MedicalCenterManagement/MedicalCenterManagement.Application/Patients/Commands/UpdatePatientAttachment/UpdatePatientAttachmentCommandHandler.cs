namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatientAttachment;

public class UpdatePatientAttachmentCommandHandler(
    IMedicalCenterManagementDbContext context,
    IFileStorageService fileStorageService
) : IHandler<UpdatePatientAttachmentCommand, Response>
{
    public async Task<Response> Handle(UpdatePatientAttachmentCommand request)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Patient>(ErrorMessages.NotFound<Patient>());

        var attachment = new Attachment(
            path: request.Attachment.Path,
            type: request.Attachment.Type
        );

        patient.AddAttachment(attachment);
        
        await fileStorageService.UploadAsync(attachment.Path, request.Stream);
        
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}