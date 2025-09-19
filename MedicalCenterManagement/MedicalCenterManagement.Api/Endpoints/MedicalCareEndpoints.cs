namespace MedicalCenterManagement.Api.Endpoints;

public static class MedicalCareEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/medical-cares";

        var mapGroup = app.MapGroup(url);

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListMedicalCaresResponseDto>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListMedicalCaresQuery());

                return Results.Ok(response);
            });

        mapGroup.MapGet("/{medicalCareId:guid}",
            [ProducesResponseType(typeof(Response<GetMedicalCareResponseDto>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid medicalCareId) =>
            {
                var response = await mediator.Publish(new GetMedicalCareQuery(medicalCareId));

                return Results.Ok(response);
            });

        mapGroup.MapPost("/create",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
            async ([FromServices] IMediator mediator, [FromBody] CreateMedicalCareCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapPut("/{medicalCareId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid medicalCareId, [FromBody] UpdateMedicalCareInputDto dto) =>
            {
                await mediator.Publish(dto.AsCommand(medicalCareId));

                return Results.NoContent();
            });

        mapGroup.MapDelete("/{medicalCareId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid medicalCareId) =>
            {
                await mediator.Publish(new DeleteMedicalCareCommand(medicalCareId));

                return Results.NoContent();
            });
    }
}