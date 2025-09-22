namespace MedicalCenterManagement.Application.Users.Commands.UpdatePassword;

public record UpdatePasswordCommand(
    Guid UserId,
    string Password
) : IRequest<Response>;

public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    public UpdatePasswordCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePasswordCommand.UserId)));

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdatePasswordCommand.Password)));
    }
}