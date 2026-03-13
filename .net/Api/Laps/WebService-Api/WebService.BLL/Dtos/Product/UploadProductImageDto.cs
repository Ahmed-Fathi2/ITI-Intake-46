using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Dtos.Product
{
    public sealed record UploadProductImageDto(IFormFile File);
   
}
