namespace MedicalCenterManagement.Application.Doctors.Commands.CreateDoctor;

public record CreateDoctorCommand(
    string Name,
    string LastName,
    DateTime Birth,
    string PhoneNumber,
    string Email,
    string Cpf,
    BloodType BloodType,
    AddressDto Address,
    Speciality Speciality,
    string Crm
) : IRequest<Response<Guid>>;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Name)))
            .MaximumLength(Doctor.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateDoctorCommand.Name), Doctor.NameMaxLength));

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Name)))
            .MaximumLength(Doctor.LastNameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateDoctorCommand.Name), Doctor.LastNameMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Birth)));

        RuleFor(command => command.PhoneNumber)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.PhoneNumber)))
            .Matches(PhoneValidation.PhoneNumberRegex)
            .WithMessage(ErrorMessages.NotFound(nameof(CreateDoctorCommand.PhoneNumber)));

        RuleFor(command => command.Email)
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Email)));

        RuleFor(command => command.Cpf)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Cpf)))
            .Matches(CpfValidation.CpfRegex)
            .WithMessage(ErrorMessages.NotFound(nameof(CreateDoctorCommand.Cpf)));

        RuleFor(command => command.BloodType)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.BloodType)));

        RuleFor(command => command.Address)
            .SetValidator(new AddressDtoValidator());

        RuleFor(command => command.Speciality)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Speciality)));

        RuleFor(command => command.Crm)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateDoctorCommand.Crm)));
    }
}