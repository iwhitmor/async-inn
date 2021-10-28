using System.Security.Claims;
using System.Threading.Tasks;
using async_inn.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace async_inn.Services.Identity
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);

        Task<UserDto> Authenticate(LoginData data);
        Task<UserDto> GetUser(ClaimsPrincipal user);
    }
}