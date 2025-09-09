using Domain.Features.Teams;

namespace Application.Features.Teams.Queries
{
    public sealed record TeamDto
    {
        public Guid Id { get; init; }

        public TeamDto(Team team)
        {
            Id = team.Id;
        }
    }
}