using Ecom.BLL.ViewModel.Role;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Managers.RoleManager
{
    public interface IRoleManager
    {
        Task<IdentityResult> AddRole(RoleCreateVM roleCreateVM);
    }
}
