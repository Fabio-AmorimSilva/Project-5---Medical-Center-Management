namespace MedicalCenterManagement.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<DeleteUserCommand, Response>
{
    public async Task<Response> Handle(DeleteUserCommand request)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
            return new NotFoundResponse<User>(ErrorMessages.NotFound<User>());

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}