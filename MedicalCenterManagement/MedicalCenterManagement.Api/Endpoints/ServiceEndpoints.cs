namespace MedicalCenterManagement.Api.Endpoints;

public static class ServiceEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/services";

        var mapGroup = app.MapGroup(url)
            .RequireAuthorization();

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListServicesResponseDto>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListServicesQuery());

                return Results.Ok(response);
            });

        mapGroup.MapGet("/{serviceId:guid}",
            [ProducesResponseType(typeof(Response<GetServiceResponseDto>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid serviceId) =>
            {
                var response = await mediator.Publish(new GetServiceQuery(serviceId));

                return Results.Ok(response);
            });

        mapGroup.MapPost("/create",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
            async ([FromServices] IMediator mediator, [FromBody] CreateServiceCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapPut("/{serviceId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid serviceId, [FromBody] UpdateServiceInputDto dto) =>
            {
                await mediator.Publish(dto.AsCommand(serviceId));

                return Results.NoContent();
            });

        mapGroup.MapDelete("/{serviceId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid serviceId) =>
            {
                await mediator.Publish(new DeleteServiceCommand(serviceId));

                return Results.NoContent();
            });
    }
}