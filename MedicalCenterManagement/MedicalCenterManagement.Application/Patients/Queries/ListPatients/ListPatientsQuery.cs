namespace MedicalCenterManagement.Application.Patients.Queries.ListPatients;

public record ListPatientsQuery : IRequest<Response<IEnumerable<ListPatientsResponseDto>>>;