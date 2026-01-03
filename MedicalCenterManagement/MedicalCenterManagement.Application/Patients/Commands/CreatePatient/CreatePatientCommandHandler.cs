namespace MedicalCenterManagement.Application.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<CreatePatientCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreatePatientCommand request)
    {
        var patient = new Patient(
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
            weight: request.Weight,
            height: request.Height,
            userId: request.UserId
        );

        var cpfAlreadyExists = await context.Persons
            .WithSpecification(new CpfAlreadyExistsSpec(patient.Cpf))
            .AnyAsync();

        if (cpfAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(patient.Cpf)));

        var emailAlreadyExists = await context.Persons
            .WithSpecification(new EmailAlreadyExistsSpec(patient.Id, patient.Email))
            .AnyAsync();

        if (emailAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(patient.Email)));

        await context.Patients.AddAsync(patient);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(patient.Id);
    }
}