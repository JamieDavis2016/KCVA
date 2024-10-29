using EnsureThat;
using Identity.API.Data;
using Identity.API.Identity;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = EnsureArg.IsNotNullOrEmpty(configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseMySQL(connectionString);
            });

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorizationBuilder();

            services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddSingleton(TimeProvider.System);

            services.AddAuthorization(options =>
                options.AddPolicy("Policies.CanPurge", policy => policy.RequireRole("Administrator")));

            return services;
        }
    }
}
