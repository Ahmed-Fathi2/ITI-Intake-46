using Ecom.BLL.ViewModel.ProductVM;
using Ecom.DAL.Repositories.UnitOfWork;
using WebApplication2.Ecom.DAL.Models;

namespace Ecom.BLL.Managers.ProductManager
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

        public IEnumerable<ProductReadVM> GetAllProducts()
        {
            return _unitOfWork.ProductRepository.GetAllWithCategories()
                .Select(p => new ProductReadVM
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Count = p.Count,
                Category=p.Category.Name

            });
        }

        public ProductReadDetailsVM? GetProductById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByIdWithCategory(id);

            if(product == null)
            {
                return null;
            }

            return new ProductReadDetailsVM
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                Category = product.Category.Name

            };
        }

        public void AddProduct(ProductCreateVM prductCreateVM)
        {

            var product = new Product
            {
                Name = prductCreateVM.Name,
                Description = prductCreateVM.Description,
                Price = prductCreateVM.Price,
                Count = prductCreateVM.Count,
                CategoryId=prductCreateVM.CategoryId,
                ImageUrl = prductCreateVM.ImageUrl
                
            };

            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();
        }

        public bool RemoveProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);

            if (product == null)
            {
                return false;
            }
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.Save();
            return true;
        }

        public bool UpdateProduct(ProductEditVM productEditVM)
        {
            var product = _unitOfWork.ProductRepository.GetById(productEditVM.Id);
            if(product == null)
            {
                return false; 
            }
            product.Name = productEditVM.Name;
            product.Description = productEditVM.Description;
            product.Price = productEditVM.Price;
            product.Count = productEditVM.Count;

            _unitOfWork.Save();
            return true;


        }

        public ProductEditVM? GetProductByIdForEdit(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByIdWithCategory(id);

            if (product == null)
            {
                return null;
            }

            return new ProductEditVM
            {
                Id=product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.Category.Id,
                CategoryName = product.Category.Name,

            };
        }
    }
}
