namespace MedicalCenterManagement.Application.Common.Interfaces;

public interface ICalendarServiceWrapper
{
    Task<IEnumerable<Event>> ListEventsAsync(string calendarId);
    Task<Event> CreateEventAsync(string calendarId, Event @event);
}