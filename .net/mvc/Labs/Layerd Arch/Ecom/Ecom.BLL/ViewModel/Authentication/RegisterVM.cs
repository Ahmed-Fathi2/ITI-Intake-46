using System.ComponentModel.DataAnnotations;

namespace Ecom.BLL.ViewModel.Authentication
{
    public class RegisterVM
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string FirstName { get; set; }


        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //public string Username { get; set; }

    }
}
