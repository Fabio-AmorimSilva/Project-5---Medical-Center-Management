namespace MedicalCenterManagement.Application.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdateDoctorCommand, Response>
{
    public async Task<Response> Handle(UpdateDoctorCommand request)
    {
        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<Doctor>(ErrorMessages.NotFound<Doctor>());

        doctor.Update(
            speciality: request.Speciality,
            crm: request.Crm
        );

        var crmAlreadyExists = await context.Doctors
            .WithSpecification(new CrmAlreadyExists(doctor.Id, doctor.Crm))
            .AnyAsync();

        if (crmAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(doctor.Crm)));

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}