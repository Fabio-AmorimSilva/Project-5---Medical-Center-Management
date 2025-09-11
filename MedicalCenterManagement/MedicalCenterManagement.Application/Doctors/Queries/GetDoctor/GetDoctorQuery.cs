namespace MedicalCenterManagement.Application.Doctors.Queries.GetDoctor;

public record GetDoctorQuery(Guid DoctorId) : IRequest<Response<GetDoctorViewModel>>;