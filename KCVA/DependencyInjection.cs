using Application.Common.Interfaces;
using Infrastructure.Data;
using KCVA.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IUser, CurrentUser>();

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        return services;
    }
}