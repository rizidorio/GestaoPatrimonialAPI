using GestaoPatrimonial.Domain.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Account
{
    public interface IAuthenticate
    {
        Task<UserTokenModel> Authenticate(LoginModel model);
        Task<bool> RegisterUser(string email, string password);
        Task Logout();
    }
}
