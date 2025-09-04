using AutoBogus;
using Domain.Features.Players.Commands;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers.Players
{
    public sealed class CreatePlayerFaker : AutoFaker<CreatePlayer>
    {
        public static CreatePlayerFaker Create()
        {
            return (CreatePlayerFaker)new CreatePlayerFaker()
                .CustomInstantiator(x => new CreatePlayer(NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value, x.Random.Int(), Guid.NewGuid()));
        }

        public static CreatePlayerFaker CreateWithoutUserId()
        {
            return (CreatePlayerFaker)new CreatePlayerFaker()
                .RuleFor(x => x.userId, y => Guid.Empty)
                .CustomInstantiator(x => new CreatePlayer(NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value, x.Random.Int(), Guid.Empty));
        }
    }
}
