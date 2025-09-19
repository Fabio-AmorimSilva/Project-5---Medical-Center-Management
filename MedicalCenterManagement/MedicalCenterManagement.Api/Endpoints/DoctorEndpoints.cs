namespace MedicalCenterManagement.Api.Endpoints;

public static class DoctorEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/doctors";

        var mapGroup = app.MapGroup(url);

        mapGroup.MapPost("/create",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromBody] CreateDoctorCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListDoctorViewModel>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListDoctorsQuery());

                return Results.Ok(response);
            });

        mapGroup.MapGet("/{doctorId:guid}",
            [ProducesResponseType(typeof(Response<GetDoctorViewModel>), StatusCodes.Status200OK)]
            async ([FromRoute] Guid doctorId, [FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new GetDoctorQuery(doctorId));

                return Results.Ok(response);
            });

        mapGroup.MapPut("/{doctorId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromRoute] Guid doctorId, [FromServices] IMediator mediator, [FromBody] UpdateDoctorInputDto inputDto) =>
            {
                await mediator.Publish(inputDto.AsCommand(doctorId));

                return Results.NoContent();
            });

        mapGroup.MapDelete("/{doctorId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromRoute] Guid doctorId, [FromServices] IMediator mediator) =>
            {
                await mediator.Publish(new DeleteDoctorCommand(doctorId));

                return Results.NoContent();
            });
    }
}