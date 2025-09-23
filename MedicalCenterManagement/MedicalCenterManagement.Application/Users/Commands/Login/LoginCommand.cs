namespace MedicalCenterManagement.Application.Users.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Response<string>>;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Email)));

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginCommand.Password)));
    }
}