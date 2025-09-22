namespace MedicalCenterManagement.Application.Users.Queries.GetUser;

public class GetUserQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<GetUserQuery, Response<GetUserResponseDto>>
{
    public async Task<Response<GetUserResponseDto>> Handle(GetUserQuery request)
    {
        var user = await context.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
            return new NotFoundResponse<GetUserResponseDto>(ErrorMessages.NotFound<User>());

        return new OkResponse<GetUserResponseDto>(new GetUserResponseDto
        {
            Email = user.Email,
            Role = user.Role.Name,
            ProfileType = user.ProfileType
        });
    }
}