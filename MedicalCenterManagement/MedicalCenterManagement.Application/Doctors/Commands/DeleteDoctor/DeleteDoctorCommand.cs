namespace MedicalCenterManagement.Application.Doctors.Commands.DeleteDoctor;

public record DeleteDoctorCommand(Guid DoctorId) : IRequest<Response>;

public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorCommandValidator()
    {
        RuleFor(command => command.DoctorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteDoctorCommand.DoctorId)));
    }
}