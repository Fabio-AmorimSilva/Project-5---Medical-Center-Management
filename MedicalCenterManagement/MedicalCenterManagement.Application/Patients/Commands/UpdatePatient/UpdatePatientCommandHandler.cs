namespace MedicalCenterManagement.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(IMedicalCenterManagementDbContext context) : IHandler<UpdatePatientCommand, Response>
{
    public async Task<Response> Handle(UpdatePatientCommand request)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(d => d.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Doctor>(ErrorMessages.NotFound<Patient>());

        patient.Update(
            weight: request.Weight,
            height: request.Height
        );

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}