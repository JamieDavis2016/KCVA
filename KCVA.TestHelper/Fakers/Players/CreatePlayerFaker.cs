using AutoBogus;
using Domain.Features.Players;
using Domain.Features.Players.Commands;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers.Players
{
    public sealed class CreatePlayerFaker : AutoFaker<CreatePlayer>
    {
        public static PlayerFaker Create()
        {
            return (PlayerFaker)new PlayerFaker()
                .CustomInstantiator(x => new Player(NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value, x.Random.Int(), Guid.Empty));
        }
    }
}
