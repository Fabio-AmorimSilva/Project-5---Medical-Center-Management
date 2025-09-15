namespace MedicalCenterManagement.Application.Patients.Queries.GetPatient;

public class GetPatientQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<GetPatientQuery, Response<GetPatientResponseDto>>
{
    public async Task<Response<GetPatientResponseDto>> Handle(GetPatientQuery request)
    {
        var filterOptions = request.FilterOptions;

        var patient = await context.Patients
            .AsNoTracking()
            .WhereIf(
                filterOptions.HasPatientId(),
                p => p.Id == filterOptions.PatientId
            )
            .WhereIf(
                filterOptions.HasCpf(),
                p => p.Cpf == filterOptions.Cpf
            )
            .WhereIf(
                filterOptions.HasPhoneNumber(),
                p => p.PhoneNumber == filterOptions.PhoneNumber
            )
            .FirstAsync();

        return new OkResponse<GetPatientResponseDto>(new GetPatientResponseDto
        {
            Name = patient.Name,
            LastName = patient.LastName,
            Email = patient.Email,
            Cpf = patient.Cpf
        });
    }
}