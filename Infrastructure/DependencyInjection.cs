using Application.Features.Teams;
using Application.Features.Teams.Queries;
using Application.Features.Users;
using Application.Features.Users.Players;
using Domain.Constants;
using Domain.SeedWork;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Interceptors;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
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

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ITeamRepository), typeof(TeamRepository));
            services.AddScoped(typeof(IPlayerRepository), typeof(PlayerRepository));
            services.AddScoped(typeof(ITeamQueries), typeof(TeamQueries));

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
                options.AddPolicy("Policies.CanPurge", policy => policy.RequireRole(Roles.Administrator)));

            return services;
        }
    }
}
