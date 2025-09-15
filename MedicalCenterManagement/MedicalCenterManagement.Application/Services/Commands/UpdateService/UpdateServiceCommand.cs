namespace MedicalCenterManagement.Application.Services.Commands.UpdateService;

public record UpdateServiceCommand(
    Guid ServiceId,
    string Name,
    string Description,
    decimal Price,
    int Period
) : IRequest<Response>;

public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
{
    public UpdateServiceCommandValidator()
    {
        RuleFor(command => command.ServiceId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateServiceCommand.ServiceId)));
        
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateServiceCommand.Name)))
            .MaximumLength(Service.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateServiceCommand.Name), Service.NameMaxLength));

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateServiceCommand.Description)))
            .MaximumLength(Service.DescriptionMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateServiceCommand.Description), Service.DescriptionMaxLength));

        RuleFor(command => command.Price)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateServiceCommand.Price)));

        RuleFor(command => command.Period)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateServiceCommand.Period)));
    }
}