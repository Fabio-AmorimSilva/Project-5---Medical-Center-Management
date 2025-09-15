namespace MedicalCenterManagement.Application.Services.Commands.UpdateService;

public class UpdateServiceCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdateServiceCommand, Response>
{
    public async Task<Response> Handle(UpdateServiceCommand request)
    {
        var service = await context.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId);

        if (service is null)
            return new NotFoundResponse<Service>(ErrorMessages.NotFound<Service>());

        var serviceAlreadyExists = await context.Services
            .WithSpecification(new ServiceAlreadyExistsSpec(service.Id, request.Name))
            .AnyAsync();

        if (serviceAlreadyExists)
            return new UnprocessableResponse<Service>(ErrorMessages.MustBeUnique(nameof(request.Name)));

        service.Update(
            name: request.Name,
            description: request.Description,
            price: request.Price,
            period: request.Period
        );

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}