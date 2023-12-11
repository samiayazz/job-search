using JobSearch.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<JobSearchDbContext>(options
            => options.UseNpgsql(config.GetConnectionString("JobSearchDbConnection")));

        return services;
    }
}