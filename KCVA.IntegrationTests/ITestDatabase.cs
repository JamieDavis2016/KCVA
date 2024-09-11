using System.Data.Common;

namespace KCVA.IntegrationTests;

public interface ITestDatabase
{
    Task InitialiseAsync();

    string GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
