﻿namespace MedicalCenterManagement.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<Response<GetUserResponseDto>>;