namespace MedicalCenterManagement.Domain.Entities;

public class MedicalCare : Entity, IHasIsDeleted
{
    public string Insurance { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public TypeOfService TypeOfService { get; private set; }
    public Guid DoctorId { get; private set; }
    public Doctor Doctor { get; private set; }
    public Guid PatientId { get; private set; }
    public Patient Patient { get; private set; }
    public Guid ServiceId { get; private set; }
    public Service Service { get; private set; }
    public bool IsDeleted { get; set; }
    
    public MedicalCare(
        string insurance, 
        DateTime start, 
        DateTime end, 
        TypeOfService typeOfService,
        Doctor doctor, 
        Patient patient,
        Service service 
    )
    {
        Insurance = insurance;
        Start = start;
        End = end;
        TypeOfService = typeOfService;
        
        DoctorId = doctor.Id;
        Doctor = doctor;

        PatientId = patient.Id;
        Patient = patient;
        
        ServiceId = service.Id;
        Service = service;
    }
}