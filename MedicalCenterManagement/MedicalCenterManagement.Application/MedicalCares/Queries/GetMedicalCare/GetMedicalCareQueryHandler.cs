namespace MedicalCenterManagement.Application.MedicalCares.Queries.GetMedicalCare;

public class GetMedicalCareQueryHandler(IMedicalCenterManagementDbContext context) : IHandler<GetMedicalCareQuery, Response<GetMedicalCareResponseDto>>
{
    public async Task<Response<GetMedicalCareResponseDto>> Handle(GetMedicalCareQuery request)
    {
        var medicalCare = await context.MedicalCares
            .AsNoTracking()
            .FirstOrDefaultAsync(mc => mc.Id == request.MedicalCareId);

        if (medicalCare is null)
            return new NotFoundResponse<GetMedicalCareResponseDto>(ErrorMessages.NotFound<MedicalCare>());

        return new OkResponse<GetMedicalCareResponseDto>(new GetMedicalCareResponseDto
        {
            Insurance = medicalCare.Insurance,
            Start = medicalCare.Start,
            End = medicalCare.End,
            TypeOfService = medicalCare.TypeOfService,
            Patient = medicalCare.Patient.GetFullName(),
            Doctor = medicalCare.Doctor.GetFullName(),
            Service = medicalCare.Service.Name
        });
    }
}