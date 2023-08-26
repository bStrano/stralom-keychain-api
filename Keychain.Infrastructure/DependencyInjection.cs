using System.Diagnostics;
using System.Text;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Infrastructure.Authentication;
using Keychain.Infrastructure.Constants;
using Keychain.Infrastructure.Helpers;
using Keychain.Infrastructure.Persistence;
using Keychain.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Keychain.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.Configure<EncryptionSettings>(configurationManager.GetSection(nameof(EncryptionSettings)));
        services.Configure<JwtSettings>(configurationManager.GetSection(nameof(JwtSettings)));
        services.AddPersistance(configurationManager);
        services.AddAuth(configurationManager);
        services.AddScoped<IEncryptionHelper, EncryptionHelper>();
        return services;
    }

    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configurationManager
        )
    {
        string? connectionString = configurationManager.GetSection(nameof(DbSettings))["CONNECTION_STRING"];
        if (connectionString == null || string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("CONNECTION STRING not provided or invalid.");
        }
        services.Configure<DbSettings>(configurationManager.GetSection(nameof(DbSettings)));
        services.AddDbContext<KeychainDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IShareableSecretRepository, ShareableSecretRepository>();
        services.AddScoped<ISecretRepository, SecretRepository>();
        return services;
    }



    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}
