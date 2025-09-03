using System.Data.Common;

namespace KCVA.IntegrationTests;

public interface ITestDatabase
{
    void Initialise();

    Task InitialiseAsync();

    string GetConnection();

    void Reset();

    Task ResetAsync();

    Task DisposeAsync();
}
