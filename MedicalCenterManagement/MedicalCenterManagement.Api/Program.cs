var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

DoctorEndpoints.Map(app);
PatientEndpoints.Map(app);
ServiceEndpoints.Map(app);
MedicalCareEndpoints.Map(app);
UserEndpoints.Map(app);

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.Run();