namespace Application.Features.Teams.Queries
{
    public interface ITeamQueries
    {
        Task<TeamDto> GetTeamById(Guid id);
    }
}
