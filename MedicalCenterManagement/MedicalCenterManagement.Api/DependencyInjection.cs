namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApi()
        {
            services
                .AddGlobalExceptionHandler()
                .AddProblemDetailsService();
        
            return services;
        }

        private void AddProblemDetailsService()
        {
            services.AddProblemDetails(configure =>
            {
                configure.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                };
            });
        }

        private IServiceCollection AddGlobalExceptionHandler()
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
        
            return services;
        }
    }
}