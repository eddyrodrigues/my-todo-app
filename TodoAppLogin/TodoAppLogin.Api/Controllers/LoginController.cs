using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Infra.CommandsHandler;
using TodoApp.Infra.CommandsRequest;

namespace TodoAppLogin.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class LoginController : ControllerBase
{

  private readonly ILogger<LoginController> _logger;

  public LoginController(ILogger<LoginController> logger)
  {
      _logger = logger;
  }
  [AllowAnonymous]
  [HttpPost]
  [Route("/Token")]
  public IActionResult CreateToken(
    [FromServices]LoginCommandHandler loginCommandHandler,
    [FromBody] CreateTokenCommandRequest createTokenCommandRequest
    )
  {
    return Ok(loginCommandHandler.handle(createTokenCommandRequest));
  }
  [HttpPost]
  [Route("/NewUser")]
  public IActionResult PostCreateLogin(
    [FromServices]LoginCommandHandler loginCommandHandler,
    [FromBody] CreateUserCommandRequest createUserCommandRequest
    )
  {
    return Ok(loginCommandHandler.handle(createUserCommandRequest));
  }
}
