namespace MedicalCenterManagement.Application.Services.Queries.ListServices;

public class ListServicesQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<ListServicesQuery, Response<IEnumerable<ListServicesResponseDto>>>
{
    public async Task<Response<IEnumerable<ListServicesResponseDto>>> Handle(ListServicesQuery request)
    {
        var services = await context.Services
            .Select(s => new ListServicesResponseDto
            {
                Description = s.Description,
                Name = s.Name,
                Price = s.Price,
                Period = s.Period
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ListServicesResponseDto>>(services);
    }
}