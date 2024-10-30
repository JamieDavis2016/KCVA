using Domain.Features.Users;
using Domain.Features.Users.Commands;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KCVA.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator Mediator;

        public UserController(UserManager<ApplicationUser> userManager, ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            Mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<Guid> CreateUser(CancellationToken cancellationToken)
        {
            var userId = await Mediator.Send(new CreateUser(), CancellationToken.None);

            return userId;
        }
    }
}
