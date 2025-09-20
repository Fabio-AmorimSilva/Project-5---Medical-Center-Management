namespace MedicalCenterManagement.Domain.Entities;

public static class UserExtensions
{
    public static IEnumerable<Claim> GetClaims(this User user)
        => new List<Claim>
        {
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role.Name)
        };
}