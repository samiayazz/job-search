using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Persistence.Contexts;
using JobSearch.Persistence.Repositories;
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
            => options.UseNpgsql(config.GetConnectionString("JobSearchPgSql")));

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<JobSearchDbContext>();

        services.AddSingleton<IJobRepository, JobRepository>();

        return services;
    }
}