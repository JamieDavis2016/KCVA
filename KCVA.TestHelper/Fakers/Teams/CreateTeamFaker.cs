using AutoBogus;
using Domain.Features.Teams;
using Domain.Features.Teams.Commands;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers.Teams
{
    public sealed class CreateTeamFaker : AutoFaker<CreateTeam>
    {
        public CreateTeamFaker(
    )
        {
        }

        public static TeamFaker Create()
        {
            return (TeamFaker)new TeamFaker()
                .CustomInstantiator(x => new Team(NameFaker.Create().Generate().Value));
        }

        //public static UserFaker CreateWithParams()
        //{
        //    return (UserFaker)new UserFaker()
        //        .CustomInstantiator(x => new User(Guid.NewGuid(), email, NameFaker.Create().Generate().Value, NameFaker.Create().Generate().Value));
        //}
    }
}
