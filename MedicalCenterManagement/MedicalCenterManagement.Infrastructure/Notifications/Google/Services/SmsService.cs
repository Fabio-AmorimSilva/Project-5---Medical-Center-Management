namespace MedicalCenterManagement.Infrastructure.Notifications.Google.Services;

public class SmsService : ISmsService
{
    private readonly TwilioSettings _twilioSettings;

    public SmsService(IOptions<TwilioSettings> options)
    {
        _twilioSettings = options.Value;
        TwilioClient.Init(
            username: _twilioSettings.AccountSid,
            password: _twilioSettings.AuthToken
        );
    }

    public async Task SendMessage(string toPhoneNumber, string message)
    {
        await MessageResource.CreateAsync(
            body: message,
            from: new PhoneNumber(_twilioSettings.PhoneNumber),
            to: new PhoneNumber(toPhoneNumber)
        );
    }
}