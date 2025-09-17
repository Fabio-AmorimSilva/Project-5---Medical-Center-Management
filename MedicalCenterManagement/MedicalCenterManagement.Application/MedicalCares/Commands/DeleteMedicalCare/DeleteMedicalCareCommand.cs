namespace MedicalCenterManagement.Application.MedicalCares.Commands.DeleteMedicalCare;

public record DeleteMedicalCareCommand(Guid MedicalCareId) : IRequest<Response>;

public class DeleteMedicalCareCommandValidator : AbstractValidator<DeleteMedicalCareCommand>
{
    public DeleteMedicalCareCommandValidator()
    {
        RuleFor(command => command.MedicalCareId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(DeleteMedicalCareCommand.MedicalCareId)));
    }
}