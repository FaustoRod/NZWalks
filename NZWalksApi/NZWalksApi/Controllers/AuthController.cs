using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models.Dtos;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LogInAsync(LoginRequest login)
        {
            var user = await userService.AuthenticateAsync(login.UserName, login.Password);

            if (user is not null)
            {
                var token = await tokenHandler.CreateToken(user);
                return Ok(token);
            }

            return BadRequest();
        }
    }
}
