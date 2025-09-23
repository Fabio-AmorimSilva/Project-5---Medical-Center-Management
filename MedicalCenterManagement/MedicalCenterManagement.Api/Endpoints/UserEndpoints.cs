namespace MedicalCenterManagement.Api.Endpoints;

public class UserEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/users";

        var mapGroup = app.MapGroup(url)
            .RequireAuthorization();

        mapGroup.MapGet("/login",
            [ProducesResponseType(typeof(Response<GetUserResponseDto>), StatusCodes.Status200OK)] [AllowAnonymous]
            async ([FromServices] IMediator mediator, [FromBody] LoginCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Ok(response);
            });

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListUsersResponseDto>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListUsersQuery());

                return Results.Ok(response);
            });

        mapGroup.MapGet("/{userId:guid}",
            [ProducesResponseType(typeof(Response<GetUserResponseDto>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid userId) =>
            {
                var response = await mediator.Publish(new GetUserQuery(userId));

                return Results.Ok(response);
            });

        mapGroup.MapPost("/create",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
            [AllowAnonymous] async ([FromServices] IMediator mediator, [FromBody] CreateUserCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapPut("/{userId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid userId, [FromBody] UpdateUserInputDto dto) =>
            {
                await mediator.Publish(dto.AsCommand(userId));

                return Results.NoContent();
            });

        mapGroup.MapDelete("/{userId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid userId) =>
            {
                await mediator.Publish(new DeleteUserCommand(userId));

                return Results.NoContent();
            });
    }
}