namespace MedicalCenterManagement.Application.Services.Commands.DeleteService;

public class DeleteServiceCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<DeleteServiceCommand, Response>
{
    public async Task<Response> Handle(DeleteServiceCommand request)
    {
        var service = await context.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId);

        if (service is null)
            return new NotFoundResponse<Service>(ErrorMessages.NotFound<Service>());

        context.Services.Remove(service);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}