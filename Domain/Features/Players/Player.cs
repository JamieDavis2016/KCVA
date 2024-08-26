using Domain.Features.Players.Commands;
using Domain.SeedWork;
using EnsureThat;

namespace Domain.Features.Players
{
    public sealed class Player : Entity, IAggregateRoot
    {
        public Player(string firstName, string lastName)
        {
            Id = new Guid();
            FirstName = EnsureArg.IsNotEmptyOrWhiteSpace(firstName);
            LastName = EnsureArg.IsNotEmptyOrWhiteSpace(lastName);
        }

        public new Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        //ADD KCVANumber

        public void Update(UpdatePlayer command)
        {
            FirstName = EnsureArg.IsNotEmptyOrWhiteSpace(command.FirstName);
            LastName = EnsureArg.IsNotEmptyOrWhiteSpace(command.LastName);
        }
    }
}
