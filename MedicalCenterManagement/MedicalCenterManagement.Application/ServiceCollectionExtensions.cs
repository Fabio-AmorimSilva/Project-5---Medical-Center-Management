namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddMediator();

            return services;
        }

        private void AddMediator(params Assembly[]? assemblies)
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
}