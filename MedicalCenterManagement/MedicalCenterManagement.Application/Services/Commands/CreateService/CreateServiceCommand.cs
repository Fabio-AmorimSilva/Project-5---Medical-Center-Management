namespace MedicalCenterManagement.Application.Services.Commands.CreateService;

public record CreateServiceCommand(
    string Name,
    string Description,
    decimal Price,
    int Period
) : IRequest<Response<Guid>>;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateServiceCommand.Name)))
            .MaximumLength(Service.NameMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateServiceCommand.Name), Service.NameMaxLength));

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateServiceCommand.Description)))
            .MaximumLength(Service.DescriptionMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateServiceCommand.Description), Service.DescriptionMaxLength));

        RuleFor(command => command.Price)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateServiceCommand.Price)));

        RuleFor(command => command.Period)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateServiceCommand.Period)));
    }
}