using Ecom.BLL.Managers.AuthManager;
using Ecom.BLL.ViewModel.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthManger _authManger;

        public AuthController(IAuthManger authManger)
        {
            _authManger = authManger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }


            var result = await _authManger.Register(registerVM);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(registerVM);
            }



        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var result = await _authManger.Login(loginVM);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(loginVM);
            }
            else
            {

                return RedirectToAction("index", "Home");
            }


        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authManger.Logout();
            return RedirectToAction("Login");
        }

    }
}
