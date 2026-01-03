namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext(configuration)
            .AddJwt(configuration)
            .AddCalendar(configuration)
            .AddSms(configuration)
            .AddAzureBlobStorage(configuration);

        services.AddScoped<IPasswordHashService, PasswordHashService>();

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MedicalCenterManagementDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IMedicalCenterManagementDbContext>(provider => provider.GetRequiredService<MedicalCenterManagementDbContext>());

        return services;
    }

    private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
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

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

    private static IServiceCollection AddCalendar(this IServiceCollection services, IConfiguration configuration)
    {
            services.Configure<GoogleCalendarSettings>(
                configuration.GetSection("GoogleCalendarSettings"));

            services.AddScoped(sp =>
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

            services.AddScoped<ICalendarServiceWrapper, CalendarServiceWrapper>();

            return services;
        }

    private static IServiceCollection AddSms(this IServiceCollection services, IConfiguration configuration)
    {
            services.Configure<TwilioSettings>(
                configuration.GetSection("TwilioSettings")
            );

            services.AddScoped<ISmsService, SmsService>();

            return services;
        }

    private static IServiceCollection AddAzureBlobStorage(this IServiceCollection services, IConfiguration configuration)
    {
            services.AddScoped<IFileStorageService>(_ =>
                new AzureBlobStorageService(
                    connectionString: configuration["AzureBlobStorageSettings:ConnectionString"],
                    containerName: configuration["AzureBlobStorageSettings:ContainerName"]
                ));
        
        return services;
    }
}