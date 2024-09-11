using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respawn;
using System.Data.Common;
using Testcontainers.MySql;

namespace KCVA.IntegrationTests;

public class TestcontainersTestDatabase : ITestDatabase
{
    private readonly MySqlContainer _container;
    private DbConnection _connection = null!;
    private string _connectionString = null!;
    private Respawner _respawner = null!;

    public TestcontainersTestDatabase()
    {
        _container = new MySqlBuilder()
            .WithAutoRemove(true)
            .Build();
    }

    public async Task InitialiseAsync()
    {
        await _container.StartAsync();

        _connectionString = _container.GetConnectionString();

        _connection = new SqlConnection(_connectionString);

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(_connectionString)
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.Migrate();

        _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
        {
            TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
        });
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
        await _container.DisposeAsync();
    }
}
