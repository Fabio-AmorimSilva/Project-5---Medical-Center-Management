namespace MedicalCenterManagement.Application.Users.Queries.ListUsers;

public class ListUsersQueryHandler(
    IMedicalCenterManagementDbContext context
) : IHandler<ListUsersQuery, Response<IEnumerable<ListUsersResponseDto>>>
{
    public async Task<Response<IEnumerable<ListUsersResponseDto>>> Handle(ListUsersQuery request)
    {
        var users = await context.Users
            .Select(u => new ListUsersResponseDto
            {
                Email = u.Email,
                Role = u.Role.Name,
                ProfileType = u.ProfileType,
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ListUsersResponseDto>>(users);
    }
}