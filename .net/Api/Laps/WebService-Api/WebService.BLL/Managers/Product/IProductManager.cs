using WebService.BLL.Abstractions;
using WebService.BLL.Abstractions.Common;
using WebService.BLL.Dtos.Product;

namespace WebService.BLL.Managers.Product
{
    public interface IProductManager
    {

        Task<Result<IEnumerable<ProductsResponseDto>>> GetAllProducts();

        Task<Result<PaginatedList<ProductsResponseDto>>> GetProducts(ProductRequestFilter requestFilter);
        Task<Result<ProductDetailsResponseDto>> GetProductById(int id);
        Task<Result<ProductsResponseDto>> AddProduct(CreateProductDto createProductDto);
        Task<Result> UpdateProduct(int id, UpdateProductDto updateProductDto);
        Task<Result> DeleteProduct(int id);

    }
}
