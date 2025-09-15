namespace MedicalCenterManagement.Application.Services.Commands.DeleteService;

public record DeleteServiceCommand(Guid ServiceId) : IRequest<Response>;

public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
{
    public DeleteServiceCommandValidator()
    {
        RuleFor(command => command.ServiceId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteServiceCommand.ServiceId)));
    }
}