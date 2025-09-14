namespace MedicalCenterManagement.Application.Patients.Queries.GetPatient;

public record GetPatientQuery(GetPatientFilterOptions FilterOptions) : IRequest<Response<GetPatientResponseDto>>;