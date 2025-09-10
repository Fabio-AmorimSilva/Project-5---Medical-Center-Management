namespace MedicalCenterManagement.Domain.Specifications;

public class EmailAlreadyExists : Specification<Person>
{
    public EmailAlreadyExists(Guid personId, string email)
    {
        Query.Where(p => 
            p.Id != personId &&
            p.Email == email
        );
    }
}