namespace MedicalCenterManagement.Application.Services.Queries.GetService;

public class GetServiceQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<GetServiceQuery, Response<GetServiceResponseDto>>
{
    public async Task<Response<GetServiceResponseDto>> Handle(GetServiceQuery request)
    {
        var service = await context.Services
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == request.ServiceId);

        if (service is null)
            return new NotFoundResponse<GetServiceResponseDto>(ErrorMessages.NotFound<Service>());

        return new OkResponse<GetServiceResponseDto>(new GetServiceResponseDto
        {
            Name = service.Name,
            Description = service.Description,
            Period = service.Period,
            Price = service.Price
        });
    }
}