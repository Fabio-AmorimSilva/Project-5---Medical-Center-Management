namespace MedicalCenterManagement.Application.Users.Commands.Login;

public class LoginCommandHandler(
    IMedicalCenterManagementDbContext context,
    IPasswordHashService passwordHashService,
    ITokenService tokenService
) : IHandler<LoginCommand, Response<string>>
{
    public async Task<Response<string>> Handle(LoginCommand request)
    {
        var passwordHash = passwordHashService.HashPassword(request.Password);

        var user = await context.Users
            .FirstOrDefaultAsync(u =>
                u.Email == request.Email &&
                u.Password == passwordHash
            );

        if (user is null)
            return new NotFoundResponse<string>(ErrorMessages.NotFound<User>());

        var token = tokenService.GenerateToken(user);

        return new OkResponse<string>(token);
    }
}