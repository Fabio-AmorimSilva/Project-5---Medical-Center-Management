namespace MedicalCenterManagement.Infrastructure.Notifications.Google.Dtos;

public record TwilioSettings
{
    public string AccountSid { get; init; } = null!;
    public string AuthToken { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
}