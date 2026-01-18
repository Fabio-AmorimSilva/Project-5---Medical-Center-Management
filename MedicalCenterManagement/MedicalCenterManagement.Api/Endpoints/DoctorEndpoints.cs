namespace MedicalCenterManagement.Api.Endpoints;

public static class DoctorEndpoints
{
    public static void Map(WebApplication app)
    {
        const string url = "/api/doctors";

        var mapGroup = app.MapGroup(url)
            .RequireAuthorization(new AuthorizeAttribute { Roles = Roles.Admin})
            .RequireAuthorization(new AuthorizeAttribute { Roles = Roles.Doctor });

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

        mapGroup.MapPut("/{doctorId:guid}/update-attachment",
            [ProducesResponseType(typeof(Response), StatusCodes.Status204NoContent)]
            async (
                [FromServices] IMediator mediator,
                [FromRoute] Guid doctorId,
                IFormFile file
            ) =>
            {
                var stream = new MemoryStream();

                await file.CopyToAsync(stream);

                stream.Position = 0;

                var attachment = new AttachmentDto(file.FileName, AttachmentType.Prescription);

                await mediator.Publish(new UpdateDoctorAttachmentCommand(doctorId, attachment, stream));

                return Results.NoContent();
            });
        
        mapGroup.MapGet("/{doctorId:guid}/download-attachment",
            [ProducesResponseType(typeof(File), StatusCodes.Status200OK)]
            async (
                [FromRoute] Guid doctorId,
                [FromQuery] string path,
                [FromServices] IMediator mediator
            ) =>
            {
                var response = await mediator.Publish(new GetDoctorAttachmentQuery(doctorId, path));
                
                return Results.File(response.Data, "image/jpeg");
            });
    }
}