using System.ComponentModel.DataAnnotations;

namespace Ecom.BLL.ViewModel.Role
{
    public class RoleCreateVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}
