using AutoBogus;
using Domain.Features.Users;
using Domain.Features.Users.Commands;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers.Users
{
    public sealed class CreateUserFaker : AutoFaker<CreateUser>
    {
        public CreateUserFaker(
    )
        {
            RuleFor(x => x.Email, EmailFaker.Create().Generate().Value);
        }

        public static UserFaker Create()
        {
            return (UserFaker)new UserFaker()
                .CustomInstantiator(x => new User(Guid.NewGuid(), EmailFaker.Create().Generate().Value, NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value));
        }

        public static UserFaker CreateWithParams(string email)
        {
            return (UserFaker)new UserFaker()
                .CustomInstantiator(x => new User(Guid.NewGuid(), email, NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value));
        }
    }
}
