using Ecom.BLL.Consts;
using Ecom.BLL.ViewModel.Authentication;
using Ecom.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Managers.AuthManager
{
    public class AuthManger : IAuthManger
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthManger(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> Register(RegisterVM registerVM)
        {

            var user = new ApplicationUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                UserName = registerVM.UserName
            };


            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                return result;
            }

            else
            {
                var roleResult = await _userManager.AddToRoleAsync(user, SystemRoles.User);

                if (!roleResult.Succeeded)
                {
                    return roleResult;
                }

                return roleResult;

            }

          


        }

        public async Task<IdentityResult> Login(LoginVM loginVM)
        {

            var emailIsExist = await _userManager.FindByEmailAsync(loginVM.Email);

            if (emailIsExist == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid Email or Password " });
            }

            var result = await _signInManager.PasswordSignInAsync(emailIsExist, loginVM.Password, loginVM.RememberMe, false);
            if (!result.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid Email or Password" });
            }
            return IdentityResult.Success;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
