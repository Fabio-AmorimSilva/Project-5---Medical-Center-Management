namespace MedicalCenterManagement.Application.MedicalCares.Queries.ListMedicalCares;

public class ListMedicalCaresQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<ListMedicalCaresQuery, Response<IEnumerable<ListMedicalCaresResponseDto>>>
{
    public async Task<Response<IEnumerable<ListMedicalCaresResponseDto>>> Handle(ListMedicalCaresQuery request)
    {
        var medicalCares = await context.MedicalCares
            .AsNoTracking()
            .Select(mc => new ListMedicalCaresResponseDto
            {
                Insurance = mc.Insurance,
                Start = mc.Start,
                End = mc.End,
                TypeOfService = mc.TypeOfService,
                Patient = mc.Patient.GetFullName(),
                Doctor = mc.Doctor.GetFullName(),
                Service = mc.Service.Name
            })
            .ToListAsync();
        
        return new OkResponse<IEnumerable<ListMedicalCaresResponseDto>>(medicalCares);
    }
}