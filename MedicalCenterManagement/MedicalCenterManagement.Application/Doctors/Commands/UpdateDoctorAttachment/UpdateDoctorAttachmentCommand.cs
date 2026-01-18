namespace MedicalCenterManagement.Application.Doctors.Commands.UpdateDoctorAttachment;

public record UpdateDoctorAttachmentCommand(
    Guid DoctorId,
    AttachmentDto Attachment,
    Stream Stream
) : IRequest<Response>;

public class UpdateDoctorAttachmentCommandValidator : AbstractValidator<UpdateDoctorAttachmentCommand>
{
    public UpdateDoctorAttachmentCommandValidator()
    {
        RuleFor(command => command.DoctorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateDoctorAttachmentCommand.DoctorId)));

        RuleFor(command => command.Attachment)
            .SetValidator(new AttachmentDtoValidator());
    }
}