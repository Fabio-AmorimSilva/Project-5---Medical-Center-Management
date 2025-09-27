namespace MedicalCenterManagement.Infrastructure.Notifications.Google.Services;

public class CalendarServiceWrapper(CalendarService calendarService) : ICalendarServiceWrapper
{
    public async Task<IEnumerable<Event>> ListEventsAsync(string calendarId)
    {
        var request = calendarService.Events.List(calendarId);

        request.UpdatedMinDateTimeOffset = DateTime.UtcNow;
        request.ShowDeleted = false;
        request.SingleEvents = true;
        request.MaxResults = 10;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

        var events = await request.ExecuteAsync();

        return events.Items ?? [];
    }

    public async Task<Event> CreateEventAsync(string calendarId, Event @event)
    {
        var request = calendarService.Events.Insert(@event, calendarId);

        return await request.ExecuteAsync();
    }
}