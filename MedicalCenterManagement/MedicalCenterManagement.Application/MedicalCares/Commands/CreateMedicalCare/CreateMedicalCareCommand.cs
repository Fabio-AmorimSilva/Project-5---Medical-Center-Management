namespace MedicalCenterManagement.Application.MedicalCares.Commands.CreateMedicalCare;

public record CreateMedicalCareCommand(
    string Insurance, 
    DateTime Start, 
    DateTime End, 
    TypeOfService TypeOfService,
    Guid DoctorId, 
    Guid PatientId,
    Guid ServiceId
) : IRequest<Response<Guid>>;

public class CreateMedicalCareCommandValidator : AbstractValidator<CreateMedicalCareCommand>
{
    public CreateMedicalCareCommandValidator()
    {
        RuleFor(command => command.Insurance)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.Insurance)));
        
        RuleFor(command => command.Start)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.Start)));
        
        RuleFor(command => command.End)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.End)));
        
        RuleFor(command => command.TypeOfService)
            .IsInEnum()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.TypeOfService)));
        
        RuleFor(command => command.DoctorId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.DoctorId)));
        
        RuleFor(command => command.PatientId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.PatientId)));
        
        RuleFor(command => command.ServiceId)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateMedicalCareCommand.ServiceId)));
    }
}