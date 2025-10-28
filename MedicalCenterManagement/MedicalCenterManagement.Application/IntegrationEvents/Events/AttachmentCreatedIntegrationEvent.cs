namespace MedicalCenterManagement.Application.IntegrationEvents.Events;

public record AttachmentCreatedIntegrationEvent : IntegrationEvent
{
    public Stream File { get; init; }
    public string Name { get; init; } = null!;
    public string ContentType { get; set; }

    public AttachmentCreatedIntegrationEvent(
        Stream file,
        string name,
        string contentType
    )
    {
        File = file;
        Name = name;
        ContentType = contentType;
    }
}