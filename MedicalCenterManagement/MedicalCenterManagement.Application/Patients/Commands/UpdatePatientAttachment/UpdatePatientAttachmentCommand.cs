namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatientAttachment;

public record UpdatePatientAttachmentCommand(
    Guid PatientId, 
    IEnumerable<AttachmentDto> Attachments
) : IRequest<Response>;

public class UpdatePatientAttachmentCommandValidator : AbstractValidator<UpdatePatientAttachmentCommand>
{
    public UpdatePatientAttachmentCommandValidator()
    {
        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePatientAttachmentCommand.PatientId)));

        RuleForEach(command => command.Attachments)
            .SetValidator(new AttachmentDtoValidator());
    }
}