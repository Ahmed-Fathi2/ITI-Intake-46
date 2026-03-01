using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext dbContext = new AppDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var productReadVM = dbContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductReadVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Count = x.Count,
                    Category = x.Category.Name
                    //ImageUrl=x.ImageUrl!
                }).ToList();

            return View(productReadVM);
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
                    ImageUrl=product.ImageUrl!
                };
                return View(productReadDetailsVM);

            }
        }


        [HttpGet]
        public IActionResult Create()
        {

            var categories = dbContext.Categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }).ToList();

            var productCreateVM = new ProductCreateVM
            {
                Categories = categories
            };
            return View(productCreateVM);

        }


        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid)
            {

                var categories = dbContext.Categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                productCreateVM.Categories = categories;
                return View(productCreateVM);
            }

            //save image physically at server

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(productCreateVM.Image.FileName);

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Product");

            var dbFolderPath = Path.Combine("Images", "Product", uniqueFileName);

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                productCreateVM.Image.CopyTo(stream);

            }

            // save IamgeUrl in db
            var product = new Product
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                CategoryId = productCreateVM.CategoryId,
                ImageUrl= dbFolderPath

            };

            dbContext.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = dbContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            var categories = dbContext.Categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }).ToList();

            var productEditVM = new ProductEditVM
            {
                Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Categories = categories
            };


            return View(productEditVM);

        }


        [HttpPost]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            var product = dbContext.Products.FirstOrDefault(x=>x.Id == productEditVM.Id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            product.Name= productEditVM.Name;
            product.Description= productEditVM.Description;
            product.Price= productEditVM.Price;
            product.Count= productEditVM.Count;
            product.CategoryId= productEditVM.CategoryId;

            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return RedirectToAction("Index");
            }
            dbContext.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult IsNameExist(string name)
        {
            var isNameExist=dbContext.Products.Any(x=>x.Name== name);

            if (isNameExist)
            {
                return Json($"Product Name {name} exist");
            }
            return Json(true);
        } 
    }
}
