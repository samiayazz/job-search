using JobSearch.WebAPI.Helpers.Identity;

namespace JobSearch.WebAPI.Extensions.WebAppBuilder
{
    public static class ConfigurePresentationServicesExtension
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<UserHelper>();
        }
    }
}