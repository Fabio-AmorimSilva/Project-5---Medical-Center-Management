namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureEventBusHandlers(this IApplicationBuilder app)
    {
        var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        
        eventBus.Subscribe<AttachmentCreatedIntegrationEvent, AttachmentCreatedIntegrationEventHandler>();
        eventBus.Subscribe<MedicalCareCreatedIntegrationEvent, MedicalCareCreatedIntegrationEventHandler>();
    }
}