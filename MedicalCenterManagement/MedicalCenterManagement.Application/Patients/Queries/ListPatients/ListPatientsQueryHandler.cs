namespace MedicalCenterManagement.Application.Patients.Queries.ListPatients;

public class ListPatientsQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<ListPatientsQuery, Response<IEnumerable<ListPatientsResponseDto>>>
{
    public async Task<Response<IEnumerable<ListPatientsResponseDto>>> Handle(ListPatientsQuery request)
    {
        var patients = await context.Patients
            .Select(p => new ListPatientsResponseDto
            {
                Name = p.Name,
                LastName = p.LastName,
                Email = p.Email,
                Cpf = p.Cpf
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ListPatientsResponseDto>>(patients);
    }
}