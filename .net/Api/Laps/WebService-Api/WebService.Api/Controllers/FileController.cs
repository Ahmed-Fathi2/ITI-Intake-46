using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.BLL.Abstractions;
using WebService.BLL.Dtos.Product;
using WebService.BLL.Managers.FileManager;

namespace WebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _env;

        public FileController(IFileManager fileManager, IWebHostEnvironment env)
        {
            _fileManager = fileManager;
            _env = env;
        }
        [HttpPost("Upload")]
        public async Task<ActionResult> UploadFile([FromForm]UploadProductImageDto file)
        {
            var schema = Request.Scheme;
            var host = Request.Host.Value;
            var baseUrl = _env.WebRootPath;

           var result= await _fileManager.UploadFileAsync(file, baseUrl, schema, host);

            return result.IsSuccess? Ok(result.Value): result.ToProblem();
        }
    }
}
