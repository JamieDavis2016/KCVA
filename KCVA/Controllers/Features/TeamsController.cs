using Domain.Features.Teams.Commands;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi.Controllers.Features
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IMediator Mediator;

        public TeamsController(ILogger<TeamsController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> CreateTeam(CreateTeam command, CancellationToken cancellationToken)
        {
            var teamId = await Mediator.Send(new CreateTeam(command.Name, command.players), CancellationToken.None);

            return teamId;
        }
    }
}
