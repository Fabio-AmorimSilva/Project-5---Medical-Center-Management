namespace MedicalCenterManagement.Application.Common.Dtos;

public record AddressDto(
    string PublicArea,
    string City,
    string State,
    string Country,
    string ZipCode
);

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(dto => dto.PublicArea)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AddressDto.PublicArea)));

        RuleFor(dto => dto.City)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AddressDto.City)));

        RuleFor(dto => dto.State)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AddressDto.State)));

        RuleFor(dto => dto.Country)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AddressDto.Country)));

        RuleFor(dto => dto.ZipCode)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(AddressDto.ZipCode)))
            .Matches(ZipCodeValidation.ZipCodeRegex)
            .WithMessage(ErrorMessages.NotFound(nameof(AddressDto.ZipCode)));
    }
}