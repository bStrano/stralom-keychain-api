

using Keychain_API.Common.Errors;
using Keychain_API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Keychain_API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, KeychainProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}