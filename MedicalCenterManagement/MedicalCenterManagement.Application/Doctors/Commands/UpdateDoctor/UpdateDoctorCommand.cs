namespace MedicalCenterManagement.Application.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    Guid DoctorId,
    Speciality Speciality,
    string Crm
) : IRequest<Response>;

public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(command => command.DoctorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateDoctorCommand.DoctorId)));

        RuleFor(command => command.Speciality)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateDoctorCommand.Speciality)));

        RuleFor(command => command.Crm)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateDoctorCommand.Crm)));
    }
}