using Domain.Features.Players.Commands;
using Domain.Features.Shared;
using Domain.SeedWork;

namespace Domain.Features.Players
{
    public sealed class Player : Entity, IAggregateRoot
    {
        public Player() { }
        public Player(string firstName, string lastName)
        {
            Id = new Guid();
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
            //FirstName = firstName;
            //LastName = lastName;
        }

        public new Guid Id { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }

        //ADD KCVANumber

        public void Update(UpdatePlayer command)
        {
            FirstName = new Name(command.FirstName);
            LastName = new Name(command.LastName);
            //FirstName = command.FirstName;
            //LastName = command.LastName;
        }
    }
}
