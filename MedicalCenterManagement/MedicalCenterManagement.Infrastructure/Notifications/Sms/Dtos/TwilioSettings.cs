namespace MedicalCenterManagement.Infrastructure.Notifications.Sms.Dtos;

public record TwilioSettings
{
    public string AccountSid { get; init; } = null!;
    public string AuthToken { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
}