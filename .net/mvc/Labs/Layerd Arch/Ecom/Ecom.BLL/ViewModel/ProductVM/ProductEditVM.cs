using System.ComponentModel;

namespace Ecom.BLL.ViewModel.ProductVM
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }

        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;




        //public List<SelectListItem>? Categories { get; set; }

    }
}
