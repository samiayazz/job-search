using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Infrastructure.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        //services.AddSingleton<IUserService, IdentityUserService>();

        return services;
    }
}