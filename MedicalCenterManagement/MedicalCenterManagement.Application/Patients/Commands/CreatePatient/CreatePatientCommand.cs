namespace MedicalCenterManagement.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    string Name,
    string LastName,
    DateTime Birth,
    string PhoneNumber,
    string Email,
    string Cpf,
    BloodType BloodType,
    AddressDto Address,
    decimal Height,
    decimal Weight,
    Guid UserId
) : IRequest<Response<Guid>>;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Name)))
            .MaximumLength(Person.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreatePatientCommand.Name), Person.NameMaxLength));

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Name)))
            .MaximumLength(Person.LastNameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreatePatientCommand.Name), Person.LastNameMaxLength));

        RuleFor(command => command.Birth)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Birth)));

        RuleFor(command => command.PhoneNumber)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.PhoneNumber)))
            .Matches(PhoneValidation.PhoneNumberRegex)
            .WithMessage(ErrorMessages.NotFound(nameof(CreatePatientCommand.PhoneNumber)));

        RuleFor(command => command.Email)
            .EmailAddress()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Email)));

        RuleFor(command => command.Cpf)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Cpf)))
            .Matches(CpfValidation.CpfRegex)
            .WithMessage(ErrorMessages.NotFound(nameof(CreatePatientCommand.Cpf)));

        RuleFor(command => command.BloodType)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.BloodType)));

        RuleFor(command => command.Address)
            .SetValidator(new AddressDtoValidator());
        
        RuleFor(command => command.Weight)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Weight)));
        
        RuleFor(command => command.Height)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreatePatientCommand.Height)));
    }
}