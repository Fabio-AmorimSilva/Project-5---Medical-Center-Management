namespace MedicalCenterManagement.Infrastructure.Notifications.Google.Dtos;

public record GoogleCalendarSettings
{
    public string? ClientId { get; init; }
    public string? ClientSecret { get; init; }
    public string? ApplicationName { get; init; }
}