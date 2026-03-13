using Microsoft.AspNetCore.Identity;

namespace Ecom.DAL.Data.Models
{
    public class ApplicationRole:IdentityRole
    {
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

    }
}
