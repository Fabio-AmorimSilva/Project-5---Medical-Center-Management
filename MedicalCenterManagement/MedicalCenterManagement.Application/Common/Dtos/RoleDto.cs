namespace MedicalCenterManagement.Application.Common.Dtos;

public record RoleDto(
    Guid Id,
    string Name
);

public class RoleDtoValidator : AbstractValidator<RoleDto>
{
    public RoleDtoValidator()
    {
        RuleFor(dto => dto.Id)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(RoleDto.Id)));
        
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(RoleDto.Name)));
    }
}