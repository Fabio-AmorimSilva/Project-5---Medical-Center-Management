namespace MedicalCenterManagement.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string Email,
    string Password,
    RoleDto Role,
    ProfileType ProfileType
) : IRequest<Response<Guid>>;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.InvalidEmail());
        
        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.Password)));
        
        RuleFor(command => command.Role)
            .SetValidator(new RoleDtoValidator());
        
        RuleFor(command => command.ProfileType)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserCommand.ProfileType)));
    }
}