namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();

        return services;
    }

    private static void AddMediator(this IServiceCollection services, params Assembly[]? assemblies)
    {
        if (assemblies is null || assemblies.Length == 0)
            assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddScoped<IMediator, Mediator>();

        var types = assemblies.SelectMany(a => a.GetTypes());

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();

            foreach (var @interface in interfaces)
            {
                if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IHandler<,>))
                    services.AddTransient(@interface, type);
            }
        }
    }
}