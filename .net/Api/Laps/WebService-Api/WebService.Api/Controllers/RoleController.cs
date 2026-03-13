using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.BLL.Abstractions;
using WebService.BLL.Managers.Auth;

namespace WebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public RoleController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(string RoleName)
        {
            var result = await authManager.AddRole(RoleName);
            return result.IsSuccess? Ok():result.ToProblem();
        }
    }
}
