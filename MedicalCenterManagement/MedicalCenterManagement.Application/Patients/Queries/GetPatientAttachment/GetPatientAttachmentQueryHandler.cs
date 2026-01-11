namespace MedicalCenterManagement.Application.Patients.Queries.GetPatientAttachment;

public class GetPatientAttachmentQueryHandler (
    IMedicalCenterManagementDbContext context,
    IFileStorageService fileStorageService
): IHandler<GetPatientAttachmentQuery, Response<Stream>>
{
    public async Task<Response<Stream>> Handle(GetPatientAttachmentQuery request)
    {
        var patient = await context.Patients.FirstOrDefaultAsync(p => p.Id == request.PatientId);

        if (patient is null)
            return new NotFoundResponse<Stream>(ErrorMessages.NotFound<Patient>());

        var path = patient.GetAttachment(request.Path);

        if (path is null)
            return new NotFoundResponse<Stream>(ErrorMessages.NotFound<Attachment>());
        
        var stream = await fileStorageService.DownloadAsync(path);
        
        return new OkResponse<Stream>(stream);
    }
}