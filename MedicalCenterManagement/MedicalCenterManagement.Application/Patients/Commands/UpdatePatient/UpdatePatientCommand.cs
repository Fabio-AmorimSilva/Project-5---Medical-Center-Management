namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(
    Guid PatientId,
    decimal Weight,
    decimal Height
) : IRequest<Response>;

public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public UpdatePatientCommandValidator()
    {
        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePatientCommand.PatientId)));
        
        RuleFor(command => command.Weight)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePatientCommand.Weight)));

        RuleFor(command => command.Height)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePatientCommand.Height)));
    }
}