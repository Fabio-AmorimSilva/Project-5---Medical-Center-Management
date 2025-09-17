namespace MedicalCenterManagement.Application.MedicalCares.Commands.UpdateMedicalCare;

public record UpdateMedicalCareCommand(
    Guid MedicalCareId,
    string Insurance,
    DateTime Start,
    DateTime End,
    TypeOfService TypeOfService,
    Guid DoctorId,
    Guid PatientId,
    Guid ServiceId
) : IRequest<Response>;

public class UpdateMedicalCareCommandValidator : AbstractValidator<UpdateMedicalCareCommand>
{
    public UpdateMedicalCareCommandValidator()
    {
        RuleFor(command => command.MedicalCareId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.MedicalCareId)));

        RuleFor(command => command.Insurance)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.Insurance)));

        RuleFor(command => command.Start)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.Start)));

        RuleFor(command => command.End)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.End)));

        RuleFor(command => command.TypeOfService)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.TypeOfService)));

        RuleFor(command => command.DoctorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.DoctorId)));

        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.PatientId)));

        RuleFor(command => command.ServiceId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateMedicalCareCommand.ServiceId)));
    }
}