namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MedicalCenterManagementDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IMedicalCenterManagementDbContext>(provider => provider.GetRequiredService<MedicalCenterManagementDbContext>());
        services.AddJwt(configuration);
        services.AddCalendar(configuration);
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<ICalendarServiceWrapper, CalendarServiceWrapper>();

        return services;
    }

    private static IServiceCollection AddJwt(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettingsDto>(jwtSettings);

        var appSettings = jwtSettings.Get<JwtSettingsDto>();
        var key = Encoding.ASCII.GetBytes(appSettings.Key);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings.Audience,
                ValidIssuer = appSettings.Issuer
            };
        });

        return services;
    }

    public static IServiceCollection AddCalendar(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleCalendarSettings>(
        configuration.GetSection("GoogleCalendarSettings"));

        services.AddSingleton<CalendarService>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<GoogleCalendarSettings>>().Value;

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets: new ClientSecrets
                {
                    ClientId = settings.ClientId,
                    ClientSecret = settings.ClientSecret
                },
                scopes: [CalendarService.Scope.Calendar],
                user: "user", 
                CancellationToken.None).Result;

            return new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = settings.ApplicationName
            });
        });

        return services;
    }
}