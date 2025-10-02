namespace MedicalCenterManagement.Application.MedicalCares.Commands.CreateMedicalCare;

public class CreateMedicalCareCommandHandler(
    IMedicalCenterManagementDbContext context,
    IEventBus eventBus
) : IHandler<CreateMedicalCareCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreateMedicalCareCommand request)
    {
        var service = await context.Services.FirstOrDefaultAsync(s => s.Id == request.ServiceId);

        if (service is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Service>());

        var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == request.DoctorId);

        if (doctor is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Doctor>());

        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Service>());

        var medicalCare = new MedicalCare(
            insurance: request.Insurance,
            start: request.Start,
            end: request.End,
            typeOfService: request.TypeOfService,
            patient: patient,
            doctor: doctor,
            service: service
        );

        await context.MedicalCares.AddAsync(medicalCare);
        await context.SaveChangesAsync();

        eventBus.Publish(new MedicalCareCreatedIntegrationEvent(
            doctorPhoneNumber: doctor.PhoneNumber,
            patientPhoneNumber: patient.PhoneNumber,
            message: "Service confirmed!!",
            start: medicalCare.Start,
            end: medicalCare.End
        ));
        
        return new CreatedResponse<Guid>(medicalCare.Id);
    }
}