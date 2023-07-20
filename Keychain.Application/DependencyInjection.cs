using Keychain.Application.Services.ShareableSecret;
using Microsoft.Extensions.DependencyInjection;

namespace Keychain.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IShareableSecretService, ShareableSecretService>();

        return services;
    }
}