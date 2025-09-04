using AutoBogus;
using Domain.Features.Players;
using Domain.Features.Users;

namespace KCVA.TestHelpers.Fakers.Players
{
    public class PlayerFaker : AutoFaker<Player>
    {
        public PlayerFaker() { }

        public static PlayerFaker CreateWithParams(string firstName, string lastName, Guid userId)
        {
            return (PlayerFaker)new PlayerFaker()
                .CustomInstantiator(x => new Player(firstName, lastName, x.Random.Int(), userId));
        }

        public static Player CreateWithoutUserId()
        {
            return new PlayerFaker()
                .RuleFor(x => x.UserId, y => Guid.Empty)
                .CustomInstantiator(x => new Player(x.Name.FirstName(), x.Name.LastName(), x.Random.Int(), Guid.Empty)).Generate();
        }
    }
}
