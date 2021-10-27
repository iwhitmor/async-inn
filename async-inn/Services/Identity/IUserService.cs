using System.Threading.Tasks;
using async_inn.Models.Identity;

namespace async_inn.Services.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterData data);
    }
}