namespace MedicalCenterManagement.Application.IntegrationEvents.Events;

public record MedicalCareCreatedIntegrationEvent : IntegrationEvent
{
    public string DoctorPhoneNumber { get; init; } = null!;
    public string PatientPhoneNumber { get; init; } = null!;
    public string Message { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime End { get; init; }

    public MedicalCareCreatedIntegrationEvent(
        string doctorPhoneNumber,
        string patientPhoneNumber,
        string message,
        DateTime start,
        DateTime end
    )
    {
        DoctorPhoneNumber = doctorPhoneNumber;
        PatientPhoneNumber = patientPhoneNumber;
        Message = message;
        Start = start;
        End = end;
    }
}