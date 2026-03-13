using Ecom.BLL.ViewModel.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Managers.AuthManager
{
    public interface IAuthManger
    {
        Task<IdentityResult> Register(RegisterVM registerVM);

        Task<IdentityResult> Login(LoginVM loginVM);

        Task Logout();
    }
}
