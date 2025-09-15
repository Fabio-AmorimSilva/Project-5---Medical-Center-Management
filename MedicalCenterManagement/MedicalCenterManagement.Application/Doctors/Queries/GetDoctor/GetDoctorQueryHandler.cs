namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctor;

public class GetDoctorQueryHandler(IMedicalCenterManagementDbContext context) : IHandler<GetDoctorQuery, Response<GetDoctorViewModel>>
{
    public async Task<Response<GetDoctorViewModel>> Handle(GetDoctorQuery request)
    {
        var doctor = await context.Doctors
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<GetDoctorViewModel>(ErrorMessages.NotFound<Doctor>());

        return new OkResponse<GetDoctorViewModel>(new GetDoctorViewModel
        {
            Name = doctor.Name,
            LastName = doctor.LastName,
            Speciality = doctor.Speciality,
            Crm = doctor.Crm
        });
    }
}