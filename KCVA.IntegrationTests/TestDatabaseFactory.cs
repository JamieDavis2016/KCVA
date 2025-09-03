namespace KCVA.IntegrationTests;

public static class TestDatabaseFactory
{
    public static ITestDatabase CreateAsync()
    {
#if DEBUG
        var database = new MySqlTestDatabase();
#else
        var database = new TestcontainersTestDatabase();
#endif

        database.Initialise();

        return database;
    }
}
