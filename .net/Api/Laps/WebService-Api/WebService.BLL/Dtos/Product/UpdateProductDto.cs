using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Dtos.Product
{
    public record UpdateProductDto
    (
     string Name,
     string Description,
     int Price,
     int Count
    );
}
