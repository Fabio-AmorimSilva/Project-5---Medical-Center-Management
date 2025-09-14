namespace MedicalCenterManagement.Application.Patients.Commands.DeletePatient;

public record DeletePatientCommand(Guid PatientId) : IRequest<Response>;

public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeletePatientCommand.PatientId)));
    }
}