namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatientAttachment;

public record UpdatePatientAttachmentCommand(
    Guid PatientId, 
    AttachmentDto Attachment,
    Stream Stream
) : IRequest<Response>;

public class UpdatePatientAttachmentCommandValidator : AbstractValidator<UpdatePatientAttachmentCommand>
{
    public UpdatePatientAttachmentCommandValidator()
    {
        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePatientAttachmentCommand.PatientId)));

        RuleFor(command => command.Attachment)
            .SetValidator(new AttachmentDtoValidator());
    }
}