namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MedicalCenterManagementDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IMedicalCenterManagementDbContext>(provider => provider.GetRequiredService<MedicalCenterManagementDbContext>());
        
        return services;
    }
}