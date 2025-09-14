namespace MedicalCenterManagement.Api.Endpoints;

public class PatientEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/patients";

        var mapGroup = app.MapGroup(url);

        mapGroup.MapPost("/",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromBody] CreatePatientCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListPatientsResponseDto>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListPatientsQuery());

                return Results.Created(url, response);
            });

        mapGroup.MapGet("/patient",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromRoute] GetPatientFilterOptions filter) =>
            {
                var response = await mediator.Publish(new GetPatientQuery(filter));

                return Results.Created(url, response);
            });

        mapGroup.MapPut("/{patientId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid patientId, [FromBody] UpdatePatientPayload payload) =>
            {
                var response = await mediator.Publish(payload.AsCommand(patientId));

                return Results.Created(url, response);
            });

        mapGroup.MapDelete("/{patientId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid patientId) =>
            {
                var response = await mediator.Publish(new DeletePatientCommand(patientId));

                return Results.Created(url, response);
            });
    }
}