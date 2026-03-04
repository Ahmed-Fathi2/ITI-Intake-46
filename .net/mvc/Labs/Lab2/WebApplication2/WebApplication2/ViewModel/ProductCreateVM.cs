using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModel
{
    public class ProductCreateVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [Remote(action:"IsNameExist",controller: "Product", ErrorMessage ="Product Name Is already Exist !! ")]
        public string Name { get; set; } = string.Empty;



        [Required]
        [MinLength(15)]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        //[DisplayName("Product Name")]

        [Required]
        [Range(50,500)]
        public int Price { get; set; }

        [Required]
        [Range(10, 15)]
        public int Count { get; set; }

        [Required]
        public int CategoryId { get; set; }


        [Required]
        public IFormFile Image { get; set; }



        public List<SelectListItem>? Categories { get; set; }

    }
}
