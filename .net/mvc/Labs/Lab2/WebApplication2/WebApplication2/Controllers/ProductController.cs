using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;
using WebApplication2.Repositories.CategoryRepository;
using WebApplication2.Repositories.ProductRepository;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productReadVM = _productRepository.GetAll()
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
            var product = _productRepository.GetById(id);
                                
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

            var categories = _categoryRepository.GetAll().Select(x => new SelectListItem
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

                var categories = _categoryRepository.GetAll().Select(x => new SelectListItem
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

            _productRepository.Insert(product);
            _productRepository.Save();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            var categories = _categoryRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }).ToList();

            ViewBag.Categories = categories;

            var productEditVM = new ProductEditVM
            {
                Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
                //Categories = categories
            };


            return View(productEditVM);

        }


        [HttpPost]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            var product = _productRepository.GetById(productEditVM.Id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            product.Name= productEditVM.Name;
            product.Description= productEditVM.Description;
            product.Price= productEditVM.Price;
            product.Count= productEditVM.Count;
            product.CategoryId= productEditVM.CategoryId;

            _productRepository.Save();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if(product is null)
            {
                return RedirectToAction("Index");
            }
            _productRepository.Delete(product);
            _productRepository.Save();
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult IsNameExist(string name)
        {
            var isNameExist = _productRepository.Any(name);

            if (isNameExist)
            {
                return Json($"Product Name {name} exist");
            }
            return Json(true);
        } 
    }
}
