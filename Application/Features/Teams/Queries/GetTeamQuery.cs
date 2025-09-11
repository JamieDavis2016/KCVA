using MediatR;

namespace Application.Features.Teams.Queries
{
    public sealed record GetTeamQuery(string searchTerm) : IRequest<List<TeamDto>>;
}