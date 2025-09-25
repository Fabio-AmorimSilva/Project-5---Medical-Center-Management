namespace MedicalCenterManagement.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(
    IMedicalCenterManagementDbContext context,
    IPasswordHashService passwordHashService
) : IHandler<CreateUserCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(CreateUserCommand request)
    {
        var role = await context.Roles.FirstOrDefaultAsync(r =>
            r.Id == request.Role.Id &&
            r.Name == request.Role.Name
        );

        if (role is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Role>());

        var passwordHash = passwordHashService.HashPassword(request.Password);

        var user = new User(
            email: request.Email,
            password: passwordHash,
            role: role,
            profileType: request.ProfileType
        );

        var emailAlreadyExists = await context.Users
            .WithSpecification(new UserEmailAlreadyExists(user.Id, request.Email))
            .AnyAsync();

        if (emailAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(request.Email)));

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(user.Id);
    }
}