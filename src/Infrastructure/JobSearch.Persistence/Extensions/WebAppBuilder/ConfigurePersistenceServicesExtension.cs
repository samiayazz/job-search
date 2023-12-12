using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Domain.Entities.Identity;
using JobSearch.Persistence.Contexts;
using JobSearch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Persistence.Extensions.WebAppBuilder;

public static class ConfigurePersistenceServicesExtension
{
    public static void AddPersistenceServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<JobSearchDbContext>(options
            => options.UseNpgsql(config.GetConnectionString("JobSearchPgSql")));

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<JobSearchDbContext>();

        services.AddScoped<IJobRepository, JobRepository>();
    }
}