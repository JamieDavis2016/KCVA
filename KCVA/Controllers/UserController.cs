using Domain.Features.Users;
using Domain.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator Mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public User GetUser(CancellationToken cancellationToken)
        {
            return new User(Guid.NewGuid(), "TestUser");
        }

        [HttpPost]
        public async Task<Guid> CreateUser(CancellationToken cancellationToken)
        {
            var newLogin = await Mediator.Send(new CreateUser(), CancellationToken.None);

            return newLogin;
        }
    }
}
