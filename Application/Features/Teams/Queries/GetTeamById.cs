using MediatR;

namespace Application.Features.Teams.Queries
{
    public sealed record GetTeamById(Guid Id) : IRequest<TeamDto>;
}