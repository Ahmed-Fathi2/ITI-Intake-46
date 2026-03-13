using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Ecom.MVC.ViewModels
{
  
    public class ProductCreateViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(15)]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(50, 500)]
        public int Price { get; set; }

        [Required]
        [Range(10, 15)]
        public int Count { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IFormFile? Image { get; set; }

        public List<SelectListItem>? Categories { get; set; }
    }
}
