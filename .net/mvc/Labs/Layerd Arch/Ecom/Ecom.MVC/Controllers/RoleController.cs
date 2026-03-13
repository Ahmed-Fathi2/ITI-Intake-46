using Ecom.BLL.Managers.RoleManager;
using Ecom.BLL.ViewModel.Role;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleManager _roleManager;

        public RoleController(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateVM roleCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(roleCreateVM);
            }

            var result = await _roleManager.AddRole(roleCreateVM);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(roleCreateVM);
            }

            else
            {
            return RedirectToAction("Index","Home");

            }


        }
    }
}
