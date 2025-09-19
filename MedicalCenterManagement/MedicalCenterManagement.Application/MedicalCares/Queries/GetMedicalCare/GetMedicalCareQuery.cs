namespace MedicalCenterManagement.Application.MedicalCares.Queries.GetMedicalCare;

public record GetMedicalCareQuery(Guid  MedicalCareId) : IRequest<Response<GetMedicalCareResponseDto>>;