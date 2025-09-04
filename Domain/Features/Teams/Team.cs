using Domain.Features.Players;
using Domain.Features.Shared;
using Domain.SeedWork;

namespace Domain.Features.Teams
{
    public sealed class Team : BaseEntity, IAggregateRoot
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Team() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Team(string name)
        {
            Name = new Name(name);
        }

        public Name Name { get; private set; }
        public List<Player> Players { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RegisterTeam(List<Player> players)
        {
            Players.Clear();
            foreach (Player player in players)
            {
                AddPlayer(player);
            }
        }
    }
}
