using System.Runtime.InteropServices.JavaScript;

namespace MedicalCenterManagement.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    string Email,
    Role Role,
    ProfileType ProfileType
) : IRequest<Response>;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.UserId)));

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.InvalidEmail());

        RuleFor(command => command.Role)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.Role)));

        RuleFor(command => command.ProfileType)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateUserCommand.ProfileType)));
    }
}