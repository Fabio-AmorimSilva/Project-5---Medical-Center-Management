namespace MedicalCenterManagement.Application.Users.Queries.ListUsers;

public record ListUsersResponseDto
{
    public string Email { get; init; } = null!;
    public string Role { get; init; } = null!;
    public ProfileType ProfileType { get; init; }
}