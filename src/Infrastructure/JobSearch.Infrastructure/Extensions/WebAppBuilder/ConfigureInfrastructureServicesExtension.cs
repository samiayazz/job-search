using JobSearch.Application.Contracts.Infrastructure.Services;
using JobSearch.Infrastructure.Helpers.Encryption;
using JobSearch.Infrastructure.Services.JobPost;
using JobSearch.Infrastructure.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure.Extensions.WebAppBuilder;

public static class ConfigureInfrastructureServicesExtension
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, IdentityUserService>();
        services.AddScoped<IJobService, JobService>();

        services.AddScoped<EncryptionHelper>();
    }
}