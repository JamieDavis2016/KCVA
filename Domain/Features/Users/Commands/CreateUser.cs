using MediatR;

namespace Domain.Features.Users.Commands
{
    public sealed class CreateUser : IRequest<Guid>
    {
        public CreateUser(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
