var builder = WebApplication.CreateBuilder(args);

builder
    .AddUserProvider()
    .AddRabbitMq(builder.Configuration);

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddAuthorization();

builder.Services.AddAntiforgery(options =>
{
    options.SuppressXFrameOptionsHeader = true;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalCenterManagement.Api v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

DoctorEndpoints.Map(app);
PatientEndpoints.Map(app);
ServiceEndpoints.Map(app);
MedicalCareEndpoints.Map(app);
UserEndpoints.Map(app);

app.UseExceptionHandler();

app.ConfigureEventBusHandlers();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.Run();