using System;
using System.Security.Claims;
using System.Threading.Tasks;
using async_inn.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace async_inn.Services.Identity
{

    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtService jwtservice;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtService jwtservice, ILogger<IdentityUserService> logger)
        {
            this.userManager = userManager;
            this.jwtservice = jwtservice;
            Logger = logger;
        }

        public ILogger<IdentityUserService> Logger { get; }

        public async Task<UserDto> Authenticate(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                return await CreateUserDto(user);
            }

            Logger.LogInformation("Invalid login for username '{Username}'", data.Username);
            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user == null) return null; 
            return await CreateUserDto(user);
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return await CreateUserDto(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserDto> CreateUserDto(ApplicationUser user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,

                Token = await jwtservice.GetToken(user, TimeSpan.FromMinutes(5)),
            };
        }
    }
}
