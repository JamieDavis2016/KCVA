using MediatR;

namespace Domain.Features.Players.Commands
{
    public sealed record CreatePlayer(string firstName, string lastName, int KcvaNumber, Guid userId) : IRequest<Guid>;
}
