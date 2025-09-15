namespace MedicalCenterManagement.Domain.Specifications;

public sealed class EmailAlreadyExistsSpec : Specification<Person>
{
    public EmailAlreadyExistsSpec(Guid personId, string email)
    {
        Query.Where(p => 
            p.Id != personId &&
            p.Email == email
        );
    }
}