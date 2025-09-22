namespace MedicalCenterManagement.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IRequest<Response>;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteUserCommand.UserId)));
    }
}