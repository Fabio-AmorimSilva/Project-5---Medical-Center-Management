namespace MedicalCenterManagement.Infrastructure.Auth.Dtos;

public sealed record JwtSettingsDto
{
    public string Key { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public int Expiration { get; init; }
}