namespace MedicalCenterManagement.Domain.Entities;

public class Patient : Person, IHasIsDeleted
{
    public decimal Height { get; private set; }
    public decimal Weight { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    
    private readonly List<Attachment> _attachments = [];
    public IReadOnlyCollection<Attachment> Attachments => _attachments;

    private Patient()
    {
    }
    
    public Patient(
        decimal height,
        decimal weight, 
        string name, 
        string lastName,
        DateTime birth, 
        string phoneNumber, 
        string email, 
        string cpf, 
        BloodType bloodType, 
        Address address,
        Guid userId
    ) : base(name, lastName, birth, phoneNumber, email, cpf, bloodType, address)
    {
        Guard.IsNotDefault(height);
        Guard.IsNotDefault(weight);
        
        UserId = userId;
        Height = height;
        Weight = weight;
    }

    public void Update(
        decimal height,
        decimal weight
    )
    {
        Guard.IsNotDefault(height);
        Guard.IsNotDefault(weight);
        
        Height = height;
        Weight = weight;
    }
    
    public void AddAttachment(Attachment attachment)
        => _attachments.Add(attachment);

    public void DeleteAttachment(Attachment attachment)
        => _attachments.Remove(attachment);

    public string? GetAttachment(string path)
    {
        return _attachments.FirstOrDefault(att => att.Path == path)?.Path;
    }
}