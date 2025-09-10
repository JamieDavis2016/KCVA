using Application.Features.Teams.Queries;
using Domain.Features.Teams.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi.Controllers.Features
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IMediator Mediator;
        private readonly ITeamQueries _teamQueries;

        public TeamsController(ILogger<TeamsController> logger, IMediator mediator, ITeamQueries teamQueries)
        {
            _logger = logger;
            Mediator = mediator;
            _teamQueries = teamQueries;
        }

        [HttpPost]
        public async Task<Guid> CreateTeam(CreateTeam command, CancellationToken cancellationToken)
        {
            var teamId = await Mediator.Send(new CreateTeam(command.Name, command.players), CancellationToken.None);

            return teamId;
        }

        [HttpGet]
        public async Task<TeamDto> GetTeamById(Guid id)
        {
            if(id == Guid.Empty)
            {
                new Exception("Id is not valid");
            }

            return await Mediator.Send(new GetTeamById(id), CancellationToken.None);
        }
    }
}
