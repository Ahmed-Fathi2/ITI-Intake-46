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


      
        public IActionResult Create()
        {
            return View();
        }
      
        public IActionResult ActualCreate(Product product)
        {
            products.Add(product);
            return RedirectToAction("GetAll");
        }
        
        public IActionResult Edit(int id)
        {
            var proToUpdate = products.FirstOrDefault(e => e.Id == id);
            if (proToUpdate == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(proToUpdate);
        }
        
       
        public IActionResult ActualEdit(Product product)
        {
            var proToUpdate = products.FirstOrDefault(e => e.Id == product.Id);
            if (proToUpdate == null)
            {
                return RedirectToAction("GetAll");
            }
            proToUpdate.Name = product.Name;
            proToUpdate.Description = product.Description;
            proToUpdate.Price = product.Price;
            proToUpdate.Count = product.Count;

            return RedirectToAction("GetAll");
        }
       
        public IActionResult Delete(int id)
        {
            var proToDelete = products.FirstOrDefault(e => e.Id == id);
            if (proToDelete == null)
            {
                return RedirectToAction("GetAll");
            }
            products.Remove(proToDelete);
            return RedirectToAction("GetAll");
        }

    }
}
