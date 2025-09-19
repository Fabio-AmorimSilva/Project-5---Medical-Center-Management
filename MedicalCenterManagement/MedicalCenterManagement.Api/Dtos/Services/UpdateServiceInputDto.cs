using MedicalCenterManagement.Application.Services.Commands.UpdateService;

namespace MedicalCenterManagement.Api.Payloads.Services;

public record UpdateServiceInputDto(
    string Name,
    string Description,
    decimal Price,
    int Period
)
{
    public UpdateServiceCommand AsCommand(Guid serviceId)
        => new(
            ServiceId: serviceId,
            Name: Name,
            Description: Description,
            Price: Price,
            Period: Period
        );
};