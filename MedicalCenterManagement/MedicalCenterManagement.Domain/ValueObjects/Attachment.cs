namespace MedicalCenterManagement.Domain.ValueObjects;

public class Attachment : ValueObject
{
    public string Name { get; private set; }
    public string ContentType { get; private set; }
    public long Size { get; private set; }
    public DateTime UploadedAt { get; private set; }

    private Attachment()
    {
    } 

    public Attachment(
        string name,
        string contentType,
        long size
    )
    {
        Name = name;
        ContentType = contentType;
        Size = size;
        UploadedAt = DateTime.UtcNow;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return ContentType;
        yield return Size;
    }
}