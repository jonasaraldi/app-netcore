using Application.Providers.Users;
using Application.Updaters.Users;
using CrossCutting.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : AppController
    {
        private readonly IUserUpdater _userUpdater;

        public UserController(IUserUpdater userUpdater)
        {
            _userUpdater = userUpdater;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAsync(UserDto dto)
            => ResultHandler(await _userUpdater.CreateAsync(dto));

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync(UserAutenticationDto dto)
            => ResultHandler(await _userUpdater.LoginAsync(dto));

        [HttpGet("teste")]
        [AllowAnonymous]
        public string Teste() => $"teste";

        [HttpGet("teste-auth")]
        [Authorize]
        public string TesteAuth() => $"teste-auth => { User.Identity.Name }";

        [HttpGet("teste-role")]
        [Authorize(Roles = "admin")]
        public string TesteRole() => $"teste-role";
    }
}