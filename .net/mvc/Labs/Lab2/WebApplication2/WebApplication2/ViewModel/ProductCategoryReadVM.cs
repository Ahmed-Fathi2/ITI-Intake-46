using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace WebApplication2.ViewModel
{
    public class ProductCategoryReadVM
    {
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }

        public  List<SelectListItem> Categories { get; set; }=new List<SelectListItem>();
    }
}
