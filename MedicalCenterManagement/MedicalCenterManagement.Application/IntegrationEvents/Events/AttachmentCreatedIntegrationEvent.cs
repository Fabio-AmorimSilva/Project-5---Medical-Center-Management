namespace MedicalCenterManagement.Application.IntegrationEvents.Events;

public record AttachmentCreatedIntegrationEvent : IntegrationEvent
{
    public string Path { get; init; } = null!;

    public AttachmentCreatedIntegrationEvent(
        string path
    )
    {
        Path = path;
    }
}