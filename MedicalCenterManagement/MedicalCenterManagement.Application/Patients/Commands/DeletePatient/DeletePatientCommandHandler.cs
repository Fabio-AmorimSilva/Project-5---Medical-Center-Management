namespace MedicalCenterManagement.Application.Patients.Commands.DeletePatient;

public class DeletePatientCommandHandler(IMedicalCenterManagementDbContext context) : IHandler<DeletePatientCommand, Response>
{
    public async Task<Response> Handle(DeletePatientCommand request)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Patient>(ErrorMessages.NotFound<Patient>());

        context.Patients.Remove(patient);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}