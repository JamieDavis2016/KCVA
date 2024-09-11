using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace KCVA.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _mysqlDatabase;

        public CustomWebApplicationFactory(string database)
        {
            _mysqlDatabase = database;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<DbContextOptions<ApplicationDbContext>>()
                    .AddDbContext<ApplicationDbContext>((sp, options) =>
                    {
                        options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                        options.UseMySQL(_mysqlDatabase);
                    });

            });
        }
    }
}
