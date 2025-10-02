namespace MedicalCenterManagement.Application.IntegrationEvents.EventHandling;

public class MedicalCareCreatedIntegrationEventHandler(
    ISmsService smsService,
    ICalendarServiceWrapper calendarServiceWrapper
) : IIntegrationEventHandler<MedicalCareCreatedIntegrationEvent>
{
    public async Task HandleAsync(MedicalCareCreatedIntegrationEvent @event)
    {
        await smsService.SendMessage(
            phoneNumber: @event.DoctorPhoneNumber,
            message: @event.Message
        );

        await smsService.SendMessage(
            phoneNumber: @event.PatientPhoneNumber,
            message: @event.Message
        );

        var calendarEvent = new Event
        {
            Summary = "Service confirmed!!",
            Start = new EventDateTime { DateTimeDateTimeOffset = @event.Start },
            End = new EventDateTime { DateTimeDateTimeOffset = @event.End }
        };

        await calendarServiceWrapper.CreateEventAsync(
            calendarId: "primary",
            @event: calendarEvent
        );
    }
}