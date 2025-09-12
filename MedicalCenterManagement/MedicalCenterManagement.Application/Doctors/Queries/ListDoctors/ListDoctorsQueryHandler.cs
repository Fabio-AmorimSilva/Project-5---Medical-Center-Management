namespace MedicalCenterManagement.Application.Doctors.Queries.ListDoctors;

public class ListDoctorsQueryHandler(IMedicalCenterManagementDbContext context) : IHandler<ListDoctorsQuery, Response<IEnumerable<ListDoctorViewModel>>>
{
    public async Task<Response<IEnumerable<ListDoctorViewModel>>> Handle(ListDoctorsQuery request)
    {
        var doctors = await context.Doctors
            .Select(d => new ListDoctorViewModel
            {
                Name = d.Name,
                LastName = d.LastName,
                Crm = d.Crm,
                Speciality = d.Speciality
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ListDoctorViewModel>>(doctors);
    }
}