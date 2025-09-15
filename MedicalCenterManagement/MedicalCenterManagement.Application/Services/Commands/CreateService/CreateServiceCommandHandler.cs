namespace MedicalCenterManagement.Application.Services.Commands.CreateService;

public class CreateServiceCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<CreateServiceCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreateServiceCommand request)
    {
        var service = new Service(
            name: request.Name,
            description: request.Description,
            price: request.Price,
            period: request.Period
        );

        var serviceAlreadyExists = await context.Services
            .WithSpecification(new ServiceAlreadyExistsSpec(service.Id, service.Name))
            .AnyAsync();

        if (serviceAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(service.Name)));

        await context.Services.AddAsync(service);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(service.Id);
    }
}