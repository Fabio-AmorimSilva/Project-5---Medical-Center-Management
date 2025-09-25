namespace MedicalCenterManagement.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdateUserCommand, Response>
{
    public async Task<Response> Handle(UpdateUserCommand request)
    {
        var role = await context.Roles.FirstOrDefaultAsync(r =>
            r.Id == request.Role.Id &&
            r.Name == request.Role.Name
        );

        if (role is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Role>());
        
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
            return new NotFoundResponse<User>(ErrorMessages.NotFound<User>());

        user.Update(
            email: request.Email,
            role: role,
            profileType: request.ProfileType
        );

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}