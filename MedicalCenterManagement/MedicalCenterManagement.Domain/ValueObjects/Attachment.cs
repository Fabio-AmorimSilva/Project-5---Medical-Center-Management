namespace MedicalCenterManagement.Domain.ValueObjects;

public class Attachment : ValueObject
{
    public string Path { get; private set; }
    public AttachmentType Type { get; private set; }

    private Attachment()
    {
    } 

    public Attachment(
        string path,
        AttachmentType type
    )
    {
        Path = path;
        Type = type;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Path;
        yield return Type;
    }
}