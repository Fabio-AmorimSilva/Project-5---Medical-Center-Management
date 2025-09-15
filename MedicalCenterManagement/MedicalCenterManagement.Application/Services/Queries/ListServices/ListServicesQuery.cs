namespace MedicalCenterManagement.Application.Services.Queries.ListServices;

public record ListServicesQuery : IRequest<Response<IEnumerable<ListServicesResponseDto>>>;