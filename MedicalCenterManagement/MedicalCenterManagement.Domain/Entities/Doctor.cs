namespace MedicalCenterManagement.Domain.Entities;

public class Doctor : Person, IHasIsDeleted
{
    public Speciality Speciality { get; private set; }
    public string Crm { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    private readonly List<Attachment> _attachments = [];
    public IReadOnlyCollection<Attachment> Attachments => _attachments;

    private Doctor()
    {
    }

    public Doctor(
        Speciality speciality,
        string crm,
        string name,
        string lastName,
        DateTime birth,
        string phoneNumber,
        string email,
        string cpf,
        BloodType bloodType,
        Address address
    ) : base(name, lastName, birth, phoneNumber, email, cpf, bloodType, address)
    {
        Guard.IsNotWhiteSpace(crm);

        Speciality = speciality;
        Crm = crm;
    }

    public void Update(
        Speciality speciality,
        string crm
    )
    {
        Guard.IsNotWhiteSpace(crm);

        Speciality = speciality;
        Crm = crm;
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