using System.Diagnostics;
using Keychain.Application.Common.Interfaces.Helpers;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Infrastructure.Constants;
using Keychain.Infrastructure.Helpers;
using Keychain.Infrastructure.Persistence;
using Keychain.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Keychain.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        string? connectionString = configurationManager.GetSection(nameof(DbSettings))["CONNECTION_STRING"];
        if (connectionString == null || string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("CONNECTION STRING not provided or invalid.");
        }
        services.Configure<DbSettings>(configurationManager.GetSection(nameof(DbSettings)));
        services.Configure<EncryptionSettings>(configurationManager.GetSection(nameof(EncryptionSettings)));
        services.AddDbContext<KeychainDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IShareableSecretRepository, ShareableSecretRepository>();
        services.AddScoped<IEncryptionHelper, EncryptionHelper>();
        return services;
    }
}
