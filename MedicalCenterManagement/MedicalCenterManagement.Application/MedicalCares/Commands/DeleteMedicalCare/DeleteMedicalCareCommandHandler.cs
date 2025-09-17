namespace MedicalCenterManagement.Application.MedicalCares.Commands.DeleteMedicalCare;

public class DeleteMedicalCareCommandHandler(IMedicalCenterManagementDbContext context) : IHandler<DeleteMedicalCareCommand, Response>
{
    public async Task<Response> Handle(DeleteMedicalCareCommand request)
    {
        var medicalCare = await context.MedicalCares.FirstOrDefaultAsync(m => m.Id == request.MedicalCareId);
        
        if (medicalCare is null)
            return new NotFoundResponse<MedicalCare>(ErrorMessages.NotFound<MedicalCare>());
        
        context.MedicalCares.Remove(medicalCare);
        await context.SaveChangesAsync();
        
        return new NoContentResponse();
    }
}