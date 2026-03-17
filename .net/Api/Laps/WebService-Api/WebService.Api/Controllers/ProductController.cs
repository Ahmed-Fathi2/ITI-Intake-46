using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebService.BLL.Abstractions;
using WebService.BLL.Abstractions.Constants;
using WebService.BLL.Dtos.Product;
using WebService.BLL.Managers.Product;

namespace WebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductsResponseDto>>> GetAllProducts()
        //{
        //    var result = await _productManager.GetAllProducts();
        //    return Ok(result.Value);
        //}

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<PaginatedList<ProductsResponseDto>>> GetAllProducts([FromQuery] ProductRequestFilter requestFilter)
        {
            var result = await _productManager.GetProducts(requestFilter);
            //throw new Exception("Error");
            return Ok(result.Value);
        }


        [HttpGet("{id}")]
        [Authorize(Roles =DefaultRole.Admin)]
        public async Task<ActionResult<ProductsResponseDto>> GetProductById([FromRoute] int id)
        {
            var result = await _productManager.GetProductById(id);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
        {
            var result = await _productManager.AddProduct(createProductDto);
            return CreatedAtAction("GetProductById", new { id = result.Value.Id }, result.Value);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var result = await _productManager.UpdateProduct(id, updateProductDto);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var result = await _productManager.DeleteProduct(id);
            return result.IsSuccess ? NoContent() : result.ToProblem();

        }
    }
}
