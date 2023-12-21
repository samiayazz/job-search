using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Application.Extensions.WebAppBuilder;

public static class ConfigureApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
    }
}
