
using Ecom.BLL.ViewModel.ProductVM;

namespace Ecom.BLL.Managers.ProductManager
{
    public interface IProductManager
    {
        IEnumerable<ProductReadVM> GetAllProducts();

        ProductReadDetailsVM? GetProductById(int id);

        ProductEditVM? GetProductByIdForEdit(int id);

        void AddProduct(ProductCreateVM prductCreateVM);


        bool UpdateProduct(ProductEditVM productEditVM);

        bool RemoveProduct(int id);
    }
}
