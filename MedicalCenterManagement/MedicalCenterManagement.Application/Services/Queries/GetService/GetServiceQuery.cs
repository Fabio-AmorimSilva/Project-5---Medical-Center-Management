namespace MedicalCenterManagement.Application.Services.Queries.GetService;

public record GetServiceQuery(Guid ServiceId) : IRequest<Response<GetServiceResponseDto>>;