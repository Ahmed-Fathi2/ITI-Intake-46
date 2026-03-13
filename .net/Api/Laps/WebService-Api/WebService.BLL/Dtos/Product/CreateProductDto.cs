using WebService.DAL;

namespace WebService.BLL.Dtos.Product
{
    public record CreateProductDto
    (

     string Name,
     string Description,
     int Price,
     int Count,
     string ImageUrl,
     int CategoryId
    );
}
