using Domain.Features.Users.Commands;
using Domain.SeedWork;
using EnsureThat;

namespace Domain.Features.Users
{
    public class User : Entity, IAggregateRoot
    {
        public User(Guid loginId, string email)
        {
            Id = new Guid();
            LoginId = EnsureArg.IsNotDefault(loginId);
            Email = EnsureArg.IsNotEmptyOrWhiteSpace(email);
        }

        public new Guid Id { get; private set; }
        public Guid LoginId { get; private set; }
        public string Email { get; private set; }

        public void Update(UpdateUser command)
        {
            Email = EnsureArg.IsNotEmptyOrWhiteSpace(command.Email);
        }
    }
}