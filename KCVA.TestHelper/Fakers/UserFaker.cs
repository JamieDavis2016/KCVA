using AutoBogus;
using Domain.Features.Users;

namespace KCVA.TestHelper.Fakers
{
    public class UserFaker : AutoFaker<User>
    {
        public UserFaker(
            ) {
            RuleFor(x => x.Email, t => t.Internet.Email());
        }

        public static UserFaker CreateWithParams(string email)
        {
            return (UserFaker)new UserFaker()
                .CustomInstantiator(x => new User(Guid.NewGuid(), email));
        }
    }
}
