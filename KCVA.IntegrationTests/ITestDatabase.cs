using System.Data.Common;

namespace KCVA.IntegrationTests;

public interface ITestDatabase
{
    void InitialiseAsync();

    string GetConnection();

    void ResetAsync();

    Task DisposeAsync();
}
