using WebService.DAL;

namespace WebService.BLL.Dtos.Product
{
    public record ProductDetailsResponseDto
    (
        int Id,
        string Name,
        string Description,
        int Price,
        int Count,
        string CategoryName,
        string CategoryDescription
        );
}
