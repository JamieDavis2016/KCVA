using AutoBogus;
using Domain.Features.Players;
using Domain.Features.Users;

namespace KCVA.TestHelpers.Fakers
{
    public class PlayerFaker : AutoFaker<Player>
    {
        public PlayerFaker() { }

        public static PlayerFaker CreateWithParams(string firstName, string lastName, Guid userId)
        {
            return (PlayerFaker)new PlayerFaker()
                .CustomInstantiator(x => new Player(firstName, lastName, userId));
        }

        public static PlayerFaker CreateWithoutUserId()
        {
            return (PlayerFaker)new PlayerFaker()
                .CustomInstantiator(x => new Player(x.Name.FirstName(), x.Name.LastName(), Guid.Empty));
        }
    }
}
