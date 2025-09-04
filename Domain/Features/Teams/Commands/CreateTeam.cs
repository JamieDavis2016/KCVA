using Domain.Features.Players;
using MediatR;

namespace Domain.Features.Teams.Commands
{
    public sealed record CreateTeam(string Name, List<Player> players) : IRequest<Guid>;
}
