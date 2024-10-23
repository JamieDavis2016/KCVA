using Domain.Features.Shared;
using Domain.Features.Users.Commands;
using Domain.SeedWork;
using EnsureThat;

namespace Domain.Features.Users
{
    public class User : BaseEntity, IAggregateRoot
    {
        public User() { }

        public User(Guid loginId, string email)
        {
            Id = new Guid();
            LoginId = EnsureArg.IsNotDefault(loginId);
            Email = new Email(email);
            //Email = email;
        }

        public new Guid Id { get; private set; }
        public Guid LoginId { get; private set; }
        public Email Email { get; private set; }

        public void Update(UpdateUser command)
        {
            Email = new Email(command.Email);
        }
    }
}