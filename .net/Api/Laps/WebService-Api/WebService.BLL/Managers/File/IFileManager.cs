using WebService.BLL.Abstractions;
using WebService.BLL.Dtos.Product;

namespace WebService.BLL.Managers.FileManager
{
    public interface IFileManager
    {
        Task<Result<string>> UploadFileAsync(UploadProductImageDto uploadFile, string baseUrl, string? schema, string? host);
    }
}
