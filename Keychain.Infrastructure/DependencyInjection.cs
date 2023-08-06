using System.Diagnostics;
using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Infrastructure.Database;
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
            throw new Exception("CONNECTION STRING not provided or invalid." + connectionString);
        }        services.Configure<DbSettings>(configurationManager.GetSection(nameof(DbSettings)));
        services.AddDbContext<KeychainDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IShareableSecretRepository, ShareableSecretRepository>();
        return services;
    }
}
