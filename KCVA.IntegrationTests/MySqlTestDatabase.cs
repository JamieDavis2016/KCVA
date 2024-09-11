using EnsureThat;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;

namespace KCVA.IntegrationTests;

public class MySqlTestDatabase : ITestDatabase
{
    private readonly string _connectionString = null!;
    private SqlConnection _connection = null!;
    private Respawner _respawner = null!;

    public MySqlTestDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _connectionString = EnsureArg.IsNotNull(connectionString);
    }

    public async Task InitialiseAsync()
    {
        _connection = new SqlConnection(_connectionString);

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySQL(_connectionString)
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.Migrate();

        //_respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
        //{
        //    TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
        //});
    }

    public string GetConnection()
    {
        return _connection.ConnectionString;
    }

    public async Task ResetAsync()
    {
        await _respawner.ResetAsync(_connectionString);
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
    }
}
