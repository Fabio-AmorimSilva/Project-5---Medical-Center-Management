namespace MedicalCenterManagement.Application.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<CreateDoctorCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreateDoctorCommand request)
    {
        var doctor = new Doctor(
            name: request.Name,
            lastName: request.LastName,
            birth: request.Birth,
            phoneNumber: request.PhoneNumber,
            email: request.Email,
            cpf: request.Cpf,
            bloodType: request.BloodType,
            address: new Address(
                publicArea: request.Address.PublicArea,
                city: request.Address.City,
                country: request.Address.Country,
                state: request.Address.State,
                zipCode: request.Address.ZipCode
            ),
            speciality: request.Speciality,
            crm: request.Crm
        );
        
        var cpfAlreadyExists = await context.Persons
            .WithSpecification(new CpfAlreadyExists(doctor.Cpf))
            .AnyAsync();

        if (cpfAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(doctor.Cpf)));

        var emailAlreadyExists = await context.Persons
            .WithSpecification(new EmailAlreadyExists(doctor.Id, doctor.Email))
            .AnyAsync();

        if (emailAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(doctor.Email)));

        var crmAlreadyExists = await context.Doctors
            .WithSpecification(new CrmAlreadyExists(doctor.Id, doctor.Crm))
            .AnyAsync();

        if (crmAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(doctor.Crm)));

        await context.Doctors.AddAsync(doctor);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(doctor.Id);
    }
}