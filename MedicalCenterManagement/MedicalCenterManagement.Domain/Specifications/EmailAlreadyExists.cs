namespace MedicalCenterManagement.Domain.Specifications;

public class EmailAlreadyExists : Specification<Doctor>
{
    public EmailAlreadyExists(Guid doctorId, string email)
    {
        Query.Where(d =>
            d.Id != doctorId &&
            d.Email == email
        );
    }
}