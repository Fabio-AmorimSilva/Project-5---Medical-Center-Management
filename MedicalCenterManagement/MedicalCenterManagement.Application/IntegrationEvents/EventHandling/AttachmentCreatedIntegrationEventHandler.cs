namespace MedicalCenterManagement.Application.IntegrationEvents.EventHandling;

public class AttachmentCreatedIntegrationEventHandler(IFileStorageService fileStorageService)
    : IIntegrationEventHandler<AttachmentCreatedIntegrationEvent>
{
    public async Task HandleAsync(AttachmentCreatedIntegrationEvent @event)
    {
        await fileStorageService.UploadAsync(
            stream: @event.File,
            fileName: @event.Name,
            contentType: @event.ContentType
        );
    }
}