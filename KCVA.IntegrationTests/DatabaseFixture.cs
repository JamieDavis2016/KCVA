using Application.Features.Teams.Queries;

namespace KCVA.IntegrationTests
{
    [CollectionDefinition("Database collection")]
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Testing.ResetState();
            Testing.Setup();
        }

        public void Dispose()
        {
            Testing.ResetState();
        }
    }
}
