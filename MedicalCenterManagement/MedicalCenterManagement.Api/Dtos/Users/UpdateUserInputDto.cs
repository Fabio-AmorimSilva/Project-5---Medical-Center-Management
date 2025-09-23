namespace MedicalCenterManagement.Api.Dtos.Users;

public record UpdateUserInputDto(
    Guid UserId,
    string Email,
    RoleDto Role,
    ProfileType ProfileType
)
{
    public UpdateUserCommand AsCommand(Guid userId)
        => new(
            UserId: userId,
            Email: Email,
            Role: Role,
            ProfileType: ProfileType
        );
}