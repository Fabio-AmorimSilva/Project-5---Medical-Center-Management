namespace MedicalCenterManagement.Application.Users.Commands.UpdatePassword;

public class UpdatePasswordCommandHandler(
    IMedicalCenterManagementDbContext context,
    IPasswordHashService passwordHashService
) : IHandler<UpdatePasswordCommand, Response>
{
    public async Task<Response> Handle(UpdatePasswordCommand request)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
            return new NotFoundResponse<User>(ErrorMessages.NotFound<User>());

        var passwordHash = passwordHashService.HashPassword(request.Password);

        user.UpdatePassword(password: passwordHash);

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}