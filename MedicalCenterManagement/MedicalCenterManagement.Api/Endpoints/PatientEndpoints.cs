namespace MedicalCenterManagement.Api.Endpoints;

public static class PatientEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/patients";

        var mapGroup = app.MapGroup(url)
            .RequireAuthorization(new AuthorizeAttribute { Roles = Roles.Admin })
            .RequireAuthorization(new AuthorizeAttribute { Roles = Roles.Receptionist })
            .RequireAuthorization(new AuthorizeAttribute { Roles = Roles.Patient });

        mapGroup.MapGet("/",
            [ProducesResponseType(typeof(Response<IEnumerable<ListPatientsResponseDto>>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator) =>
            {
                var response = await mediator.Publish(new ListPatientsQuery());

                return Results.Ok(response);
            });

        mapGroup.MapGet("/patient",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromRoute] GetPatientFilterOptions filter) =>
            {
                var response = await mediator.Publish(new GetPatientQuery(filter));

                return Results.Ok(response);
            });

        mapGroup.MapPost("/create",
            [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status200OK)]
            async ([FromServices] IMediator mediator, [FromBody] CreatePatientCommand command) =>
            {
                var response = await mediator.Publish(command);

                return Results.Created(url, response);
            });

        mapGroup.MapPut("/{patientId:guid}/update",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid patientId, [FromBody] UpdatePatientInputDto inputDto) =>
            {
                await mediator.Publish(inputDto.AsCommand(patientId));

                return Results.NoContent();
            });

        mapGroup.MapDelete("/{patientId:guid}/delete",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async ([FromServices] IMediator mediator, [FromRoute] Guid patientId) =>
            {
                await mediator.Publish(new DeletePatientCommand(patientId));

                return Results.NoContent();
            });
        
        mapGroup.MapPut("/{patientId:guid}/update-attachments",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async (
                [FromServices] IMediator mediator, 
                [FromRoute] Guid patientId, 
                [FromBody] UpdatePatientAttachmentCommand command
            ) =>
            {
                await mediator.Publish(command with { PatientId = patientId });

                return Results.NoContent();
            });
    }
}