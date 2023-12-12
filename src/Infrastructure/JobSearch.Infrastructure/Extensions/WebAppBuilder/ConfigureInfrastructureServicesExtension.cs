using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Infrastructure.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure.Extensions.WebAppBuilder;

public static class ConfigureInfrastructureServicesExtension
{
    public static void RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, IdentityUserService>();
    }
}