using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using async_inn.Models.Identity;
using async_inn.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace async_inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data);

            if (user == null)
                return Unauthorized();

            return user;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<UserDto>> Self()
        {
            return await userService.GetUser(this.User);
        }
    }
}