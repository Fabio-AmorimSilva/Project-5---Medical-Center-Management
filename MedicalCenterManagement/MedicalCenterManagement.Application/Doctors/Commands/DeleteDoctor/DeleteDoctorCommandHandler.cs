namespace MedicalCenterManagement.Application.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorCommandHandler(IMedicalCenterManagementDbContext context) : IHandler<DeleteDoctorCommand, Response>
{
    public async Task<Response> Handle(DeleteDoctorCommand request)
    {
        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<Doctor>(ErrorMessages.NotFound<Doctor>());

        context.Doctors.Remove(doctor);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}