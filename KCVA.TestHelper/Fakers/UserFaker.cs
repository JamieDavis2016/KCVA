using AutoBogus;
using Domain.Features.Users;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers
{
    public class UserFaker : AutoFaker<User>
    {
        public UserFaker(
            )
        {
            RuleFor(x => x.Id, y => Guid.NewGuid());
            RuleFor(x => x.Email, EmailFaker.Create().Generate());
            Ignore(x => x.Created);
            Ignore(x => x.LastModified);    
        }

        public static UserFaker Create()
        {
            return (UserFaker)new UserFaker()
                .CustomInstantiator(x => new User(Guid.NewGuid(), EmailFaker.Create().Generate().Value));
        }

        public static UserFaker CreateWithParams(string email)
        {
            return (UserFaker)new UserFaker()
                .CustomInstantiator(x => new User(Guid.NewGuid(), email));
        }
    }
}
