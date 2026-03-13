using Microsoft.AspNetCore.Mvc;

namespace Ecom.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return RedirectToAction("Login","Auth");
        }
    }
}
