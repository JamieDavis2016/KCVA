using Domain.Features.Players.Commands;
using Domain.Features.Shared;
using Domain.SeedWork;

namespace Domain.Features.Players
{
    public sealed class Player : Entity, IAggregateRoot
    {
        public Player() { }
        public Player(string firstName, string lastName, int kcvaNumber,Guid userId)
        {
            Id = new Guid();
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
            KCVANumber = kcvaNumber;
            UserId = userId;
        }

        public new Guid Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Guid UserId { get; private set; }
        public int KCVANumber { get; private set; }

        public void Update(UpdatePlayer command)
        {
            FirstName = new Name(command.FirstName);
            LastName = new Name(command.LastName);
        }
    }
}
