namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            services
                .AddDbContext(configuration)
                .AddJwt(configuration)
                .AddCalendar(configuration)
                .AddSms(configuration)
                .AddAzureBlobStorage(configuration)
                .AddCaching(configuration);

            services.AddScoped<IPasswordHashService, PasswordHashService>();

            return services;
        }

        private IServiceCollection AddDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MedicalCenterManagementDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IMedicalCenterManagementDbContext>(provider => provider.GetRequiredService<MedicalCenterManagementDbContext>());

            return services;
        }

        private IServiceCollection AddJwt(IConfiguration configuration)
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

        private IServiceCollection AddCalendar(IConfiguration configuration)
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

        private IServiceCollection AddSms(IConfiguration configuration)
        {
            services.Configure<TwilioSettings>(
                configuration.GetSection("TwilioSettings")
            );

            services.AddScoped<ISmsService, SmsService>();

            return services;
        }

        private IServiceCollection AddAzureBlobStorage(IConfiguration configuration)
        {
            services.AddScoped<IFileStorageService>(_ =>
                new AzureBlobStorageService(
                    connectionString: configuration["AzureBlobStorageSettings:ConnectionString"],
                    containerName: configuration["AzureBlobStorageSettings:ContainerName"]
                ));
        
            return services;
        }
        
        private IServiceCollection AddCaching(IConfiguration configuration)
        {
            var provider = configuration.GetValue<string>("Caching:Provider");

            if (provider == "Redis")
            {
                var connectionString = configuration.GetValue<string>("Caching:Redis:ConnectionString");
                var instanceName = configuration.GetValue<string>("Caching:Redis:InstanceName");

                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = connectionString;
                    options.InstanceName = instanceName;

                    services.AddScoped<ICacheService, RedisCacheService>();
                });
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ICacheService, MemoryCacheService>();
            }

            return services;
        }
    }
}