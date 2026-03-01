using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProductCategoryController : Controller
    {
        public AppDbContext dbContext { get; set; }=new AppDbContext();

        [HttpGet]
        public IActionResult GetAllCateory()
        {
            var categories = dbContext.Categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            }).ToList();


            var productCategoryReadVM = new ProductCategoryReadVM
            {
                Categories = categories
            };


            return View(productCategoryReadVM);
        }

        [HttpGet]
        public IActionResult GetAllRelatedProduct(int catid)
        {
            
            var products = dbContext.Products
                           .Where(x => x.CategoryId == catid)
                           .Select(x => new RelatedProductReadVM
                           {
                               ProductId = x.Id,
                               ProductName = x.Name
                           })
                           .ToList();

            return Json(products);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var product = dbContext.Products
                            .Include(x => x.Category)
                            .FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var productReadDetailsVM = new ProductReadDetailsVM
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Count = product.Count,
                    Category = product.Category.Name,
                    ImageUrl = product.ImageUrl!
                };
                return PartialView("_ProductDetailsPartial", productReadDetailsVM);

            }
        }
    }
}
