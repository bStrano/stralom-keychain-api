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
        services.Configure<DbSettings>(configurationManager.GetSection(nameof(DbSettings)));
        services.AddDbContext<KeychainDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString(nameof(DbSettings))));
        services.AddScoped<IShareableSecretRepository, ShareableSecretRepository>();
        return services;
    }
}