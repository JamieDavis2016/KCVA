using AutoBogus;
using Domain.Features.Teams;
using Domain.Features.Teams.Commands;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.TestHelpers.Fakers.Teams
{
    public sealed class CreateTeamFaker : AutoFaker<CreateTeam>
    {
        public CreateTeamFaker()
        {
            this.Locale = "en_GB";
        }

        public static TeamFaker Create()
        {
            return (TeamFaker)new TeamFaker()
                .CustomInstantiator(x => new Team(NameFaker.Create().Generate().Value));
        }
    }
}
