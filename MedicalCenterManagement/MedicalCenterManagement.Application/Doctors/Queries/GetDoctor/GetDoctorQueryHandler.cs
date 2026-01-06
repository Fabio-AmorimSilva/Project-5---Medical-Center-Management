namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctor;

public class GetDoctorQueryHandler(
    IMedicalCenterManagementDbContext context,
    ICacheService cacheService
) : IHandler<GetDoctorQuery, Response<GetDoctorViewModel>>
{
    private const string CacheKey = "doctor:";
    
    public async Task<Response<GetDoctorViewModel>> Handle(GetDoctorQuery request)
    {
        var cacheKey = $"{CacheKey}{request.DoctorId}";
        
        var cachedDoctor = await cacheService.GetAsync<GetDoctorViewModel>(cacheKey);
        
        if(cachedDoctor is not null)
            return new OkResponse<GetDoctorViewModel>(cachedDoctor);
        
        var doctor = await context.Doctors
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<GetDoctorViewModel>(ErrorMessages.NotFound<Doctor>());
        
        await cacheService.SetAsync(cacheKey, doctor);
        
        return new OkResponse<GetDoctorViewModel>(new GetDoctorViewModel
        {
            Name = doctor.Name,
            LastName = doctor.LastName,
            Speciality = doctor.Speciality,
            Crm = doctor.Crm
        });
    }
}