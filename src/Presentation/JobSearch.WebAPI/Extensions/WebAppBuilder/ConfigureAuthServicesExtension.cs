using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JobSearch.WebAPI.Extensions.WebAppBuilder
{
    public static class ConfigureAuthServicesExtension
    {
        public static void AddAuthServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JwtToken:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = config["JwtToken:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtToken:SecurityKey"])),

                    ValidateLifetime = true
                };
            });
            services.AddAuthorization();
        }

        public static void UseAuthServices(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}