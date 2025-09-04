using Domain.Features.Players.Commands;
using Domain.Features.Teams.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi.Controllers.Features
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IMediator Mediator;

        public PlayersController(ILogger<PlayersController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<Guid> CreatePlayer(CreatePlayer command, CancellationToken cancellationToken)
        {
            var teamId = await Mediator.Send(new CreatePlayer(command.firstName, command.lastName, command.KcvaNumber, command.userId), CancellationToken.None);

            return teamId;
        }
    }
}
