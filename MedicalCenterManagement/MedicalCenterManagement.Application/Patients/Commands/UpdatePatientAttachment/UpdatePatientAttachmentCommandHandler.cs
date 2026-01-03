namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatientAttachment;

public class UpdatePatientAttachmentCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdatePatientAttachmentCommand, Response>
{
    public async Task<Response> Handle(UpdatePatientAttachmentCommand request)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Patient>(ErrorMessages.NotFound<Patient>());

        var attachments = request.Attachments.Select(att => new Attachment(
            path: att.Path,
            type: att.Type
        )).ToHashSet();

        patient.AddAttachments(attachments);

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}