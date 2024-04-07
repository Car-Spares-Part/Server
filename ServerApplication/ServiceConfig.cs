using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServerApplication.Services;
using SW.CqApi;
using SW.CqApi.AuthOptions;

namespace ServerApplication;

public static class ServiceConfig
{
    public static void ConfigureApp(IServiceCollection services, IConfiguration configuration, string env)
    {
        services.AddMemoryCache();
        services.AddDbContext<DatabaseContext>(c =>
        {
            c.EnableSensitiveDataLogging();
            c.UseSnakeCaseNamingConvention();
            c.UseNpgsql(configuration.GetConnectionString(DatabaseContext.ConnectionString), b =>
            {
                b.MigrationsHistoryTable("_ef_migrations_history", DatabaseContext.Schema);
                b.MigrationsAssembly(typeof(Program).Assembly.FullName);
            });
        });
        services.AddCqApi(options =>
        {
            options.UrlPrefix = "api";
            options.ProtectAll = true;

            options.AuthOptions = new CqApiAuthOptions
            {
                AuthType = AuthType.OAuth2
            };
        });
        services.AddAuthentication()
           .AddJwtBearer(configureOptions =>
            {
                configureOptions.RequireHttpsMetadata = false;
                configureOptions.SaveToken = true;
                configureOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"]))
                };
            });
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains();
                    builder.AllowCredentials();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
        });
        services.AddScoped<ICreateJWT, CreateJwt>();

    }
}