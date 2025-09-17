namespace MedicalCenterManagement.Application.MedicalCares.Commands.UpdateMedicalCare;

public class UpdateMedicalCareCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdateMedicalCareCommand, Response>
{
    public async Task<Response> Handle(UpdateMedicalCareCommand request)
    {
        var medicalCare = await context.MedicalCares.FirstOrDefaultAsync(mc => mc.Id == request.MedicalCareId);

        if (medicalCare is null)
            return new NotFoundResponse<MedicalCare>(ErrorMessages.NotFound<MedicalCare>());

        var service = await context.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId);

        if (service is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Service>());

        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Doctor>());

        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Service>());

        medicalCare.Update(
            insurance: request.Insurance,
            start: request.Start,
            end: request.End,
            typeOfService: request.TypeOfService,
            patient: patient,
            doctor: doctor,
            service: service
        );

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}