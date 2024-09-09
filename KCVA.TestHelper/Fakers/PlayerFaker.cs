using AutoBogus;
using Domain.Features.Players;

namespace KCVA.TestHelpers.Fakers
{
    public class PlayerFaker : AutoFaker<Player>
    {
        public PlayerFaker() { }

        public static PlayerFaker CreateWithParams(string firstName, string lastName)
        {
            return (PlayerFaker)new PlayerFaker()
                .CustomInstantiator(x => new Player(firstName, lastName));
        }
    }
}
