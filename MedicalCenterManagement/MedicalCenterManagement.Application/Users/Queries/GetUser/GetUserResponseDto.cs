namespace MedicalCenterManagement.Application.Users.Queries.GetUser;

public record GetUserResponseDto
{
    public string Email { get; init; } = null!;
    public string Role { get; init; } = null!;
    public ProfileType ProfileType { get; init; }
}