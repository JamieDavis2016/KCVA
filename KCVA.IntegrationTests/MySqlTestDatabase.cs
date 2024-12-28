using EnsureThat;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KCVA.IntegrationTests;

public class MySqlTestDatabase : ITestDatabase
{
    private readonly string _connectionString = null!;
    private SqlConnection _connection = null!;

    public MySqlTestDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _connectionString = EnsureArg.IsNotNull(connectionString);
    }

    public void Initialise()
    {
        _connection = new SqlConnection(_connectionString);

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySQL(_connectionString)
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.Migrate();
    }

    public string GetConnection()
    {
        return _connection.ConnectionString;
    }

    public void Reset()
    {
        _connection = new SqlConnection(_connectionString);

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySQL(_connectionString)
            .Options;

        var context = new ApplicationDbContext(options);
        context.Database.EnsureDeleted();
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
    }

    public Task InitialiseAsync()
    {
        throw new NotImplementedException();
    }

    public Task ResetAsync()
    {
        throw new NotImplementedException();
    }
}
