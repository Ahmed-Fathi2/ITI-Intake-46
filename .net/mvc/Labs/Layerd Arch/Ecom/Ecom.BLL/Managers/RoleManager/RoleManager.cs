using Ecom.BLL.ViewModel.Role;
using Ecom.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Managers.RoleManager
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleManager(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddRole(RoleCreateVM roleCreateVM)
        {
            var role= new ApplicationRole
            {
                Name = roleCreateVM.RoleName
            };

            var result = await _roleManager.CreateAsync(role);

            return result;
        }
    }
}
