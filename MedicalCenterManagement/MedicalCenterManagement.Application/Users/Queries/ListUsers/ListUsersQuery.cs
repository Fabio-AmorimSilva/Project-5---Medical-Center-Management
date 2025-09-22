namespace MedicalCenterManagement.Application.Users.Queries.ListUsers;

public record ListUsersQuery : IRequest<Response<IEnumerable<ListUsersResponseDto>>>;