namespace MedicalCenterManagement.Application.Common.Dtos;

public record AttachmentDto(
    string Path,
    AttachmentType Type
);

public class AttachmentDtoValidator : AbstractValidator<AttachmentDto>
{
    public AttachmentDtoValidator()
    {
        RuleFor(command => command.Path)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AttachmentDto.Path)));

        RuleFor(command => command.Type)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AttachmentDto.Type)));
    }
}