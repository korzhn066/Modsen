using Microsoft.AspNetCore.Identity;
using Modsen.Data;
using Modsen.Domain.Entities;

namespace Modsen.Configuration
{
    internal static class IdentityConfiguration
    {
        internal static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DBContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
