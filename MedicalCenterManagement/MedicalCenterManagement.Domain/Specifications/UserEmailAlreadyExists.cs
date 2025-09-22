namespace MedicalCenterManagement.Domain.Specifications;

public sealed class UserEmailAlreadyExists : Specification<User>
{
    public UserEmailAlreadyExists(Guid userId, string email)
    {
        Query.Where(u =>
            u.Id != userId &&
            u.Email == email
        );
    }
}