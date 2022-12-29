using Auth.DTO;
using Helpers;
using System.Threading.Tasks;

namespace Auth.IService
{
    public interface IAuth
    {
        Task<Response> Login(LoginDTO model);
        Task<Response> Register(RegisterDTO model);
        Task<Response> Logout();
    }
}
