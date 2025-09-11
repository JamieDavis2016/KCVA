namespace Application.Features.Teams.Queries
{
    public interface ITeamQueries
    {
        Task<TeamDto> GetTeamById(Guid id);

        Task<List<TeamDto>> GetTeamByQuery(string searchTerm, CancellationToken cancellationToken);
    }
}
