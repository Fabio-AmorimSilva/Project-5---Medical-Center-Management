namespace MedicalCenterManagement.Application.MedicalCares.Queries.ListMedicalCares;

public record ListMedicalCaresQuery : IRequest<Response<IEnumerable<ListMedicalCaresResponseDto>>>;