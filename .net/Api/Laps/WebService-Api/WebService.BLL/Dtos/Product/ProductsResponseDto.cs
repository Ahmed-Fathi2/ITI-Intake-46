using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Dtos.Product
{
    public record ProductsResponseDto
    (
        int Id,
        string Name,
        string Description,
        int Price,
        int Count,
        int CaterogyId,
        string CategoryName
    );
}
