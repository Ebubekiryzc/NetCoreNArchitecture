using Kodlama.io.Devs.Application.Features.Authentication.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Authentication.DTOs;
using Kodlama.io.Devs.Application.Features.Authentication.Queries.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            CreatedAccessTokenDTO createdAccessTokenDTO = await Mediator.Send(registerCommand);
            return Created("", createdAccessTokenDTO);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery loginQuery)
        {
            CreatedAccessTokenDTO createdAccessTokenDTO = await Mediator.Send(loginQuery);
            return Created("", createdAccessTokenDTO);
        }
    }
}
