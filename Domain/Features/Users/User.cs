using Domain.Features.Shared;
using Domain.Features.Users.Commands;
using Domain.SeedWork;
using EnsureThat;

namespace Domain.Features.Users
{
    public class User : BaseEntity, IAggregateRoot
    {
        public User() { }

        public User(Guid loginId, string email, string firstName, string lastName)
        {
            Id = new Guid();
            LoginId = EnsureArg.IsNotDefault(loginId);
            Email = new Email(email);
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
        }

        public new Guid Id { get; private set; }
        public Guid LoginId { get; private set; }
        public Email Email { get; private set; }
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }

        public void Update(UpdateUser command)
        {
            Email = new Email(command.Email);
        }
    }
}