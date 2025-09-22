namespace MedicalCenterManagement.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<UpdateUserCommand, Response>
{
    public async Task<Response> Handle(UpdateUserCommand request)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
            return new NotFoundResponse<User>(ErrorMessages.NotFound<User>());

        user.Update(
            email: request.Email,
            role: request.Role,
            profileType: request.ProfileType
        );

        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}