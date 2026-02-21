using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Laptop",
                Description = "Dell Laptop i7",
                Price = 25000,
                Count = 5
            },
            new Product
            {
                Id = 2,
                Name = "Mouse",
                Description = "Wireless Mouse",
                Price = 300,
                Count = 20
            },
            new Product
            {
                Id = 3,
                Name = "Keyboard",
                Description = "Mechanical Keyboard",
                Price = 1200,
                Count = 10
            },
            new Product
            {
                Id = 4,
                Name = "Monitor",
                Description = "24 inch Monitor",
                Price = 4500,
                Count = 7
            },
            new Product
            {
                Id = 5,
                Name = "Headset",
                Description = "Gaming Headset",
                Price = 900,
                Count = 12
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View(products);
        }

        public IActionResult GetById(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }

    }
}
