using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecom.BLL.ViewModel.ProductVM
{
    public class ProductCreateVM
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

        // Image path to be saved in database. The actual file upload (IFormFile) must be handled by the Presentation layer.
        public string? ImageUrl { get; set; }
    }
}
