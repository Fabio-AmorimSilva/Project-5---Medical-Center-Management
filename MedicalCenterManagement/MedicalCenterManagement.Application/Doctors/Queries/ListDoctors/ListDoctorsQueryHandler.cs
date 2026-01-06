namespace MedicalCenterManagement.Application.Doctors.Queries.ListDoctors;

public class ListDoctorsQueryHandler(
    IMedicalCenterManagementDbContext context,
    ICacheService cacheService
) : IHandler<ListDoctorsQuery, Response<IEnumerable<ListDoctorViewModel>>>
{
    private const string CacheKey = "doctors:all";
    
    public async Task<Response<IEnumerable<ListDoctorViewModel>>> Handle(ListDoctorsQuery request)
    {
        var cachedDoctors = await cacheService.GetAsync<IEnumerable<ListDoctorViewModel>>(CacheKey);
     
        if(cachedDoctors is not null)
            return new OkResponse<IEnumerable<ListDoctorViewModel>>(cachedDoctors);
        
        var doctors = await context.Doctors
            .Select(d => new ListDoctorViewModel
            {
                Name = d.Name,
                LastName = d.LastName,
                Crm = d.Crm,
                Speciality = d.Speciality
            })
            .ToListAsync();
        
        await cacheService.SetAsync(CacheKey, doctors);

        return new OkResponse<IEnumerable<ListDoctorViewModel>>(doctors);
    }
}