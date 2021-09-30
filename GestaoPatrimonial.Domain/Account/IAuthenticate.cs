using GestaoPatrimonial.Domain.AuthModels;
using GestaoPatrimonial.Domain.Utils.Models;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Account
{
    public interface IAuthenticate
    {
        Task<ResponseModel> Authenticate(LoginModel model);
        Task<ResponseModel> RegisterUser(RegisterUserModel model);
        Task Logout();
    }
}
