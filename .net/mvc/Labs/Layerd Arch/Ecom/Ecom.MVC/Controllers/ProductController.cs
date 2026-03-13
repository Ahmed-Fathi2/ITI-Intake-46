using Ecom.BLL.Consts;
using Ecom.BLL.Managers.CategoryManager;
using Ecom.BLL.Managers.ProductManager;
using Ecom.BLL.ViewModel.ProductVM;
using Ecom.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Ecom.MVC.Controllers

{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager, IWebHostEnvironment environment)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _environment = environment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var productReadVM = _productManager.GetAllProducts();

            return View(productReadVM);
        }



        [HttpGet]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var productReadDetailsVM = _productManager.GetProductById(id);

            if (productReadDetailsVM is null)
            {
                return RedirectToAction("Index");
            }

            return View(productReadDetailsVM);


        }


        [HttpGet]
        [Authorize(Roles =(SystemRoles.Admin))]
        public IActionResult Create()
        {
            var categories = _categoryManager.GetAllCategories()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

            var vm = new ProductCreateViewModel
            {
                Categories = categories
            };
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = (SystemRoles.Admin))]
        public IActionResult Create(ProductCreateViewModel productCreateVM)
        {
            if (!ModelState.IsValid)
            {
                // repopulate categories when returning view
                productCreateVM.Categories = _categoryManager.GetAllCategories()
                    .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

                return View(productCreateVM);
            }


            string? dbImagePath = null;
            if (productCreateVM.Image != null && productCreateVM.Image.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath ?? "wwwroot", "Images", "Product");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(productCreateVM.Image.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    productCreateVM.Image.CopyTo(stream);
                }


                //dbImagePath = Path.Combine("Images", "Product", uniqueFileName).Replace("\\", "/");
                dbImagePath = $"Images/Product/{uniqueFileName}";
            }


            var bllVm = new ProductCreateVM
            {
                Name = productCreateVM.Name,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                CategoryId = productCreateVM.CategoryId,
                ImageUrl = dbImagePath
            };

            _productManager.AddProduct(bllVm);

            return RedirectToAction("Index");

        }


        [HttpGet]
        [Authorize(Roles = (SystemRoles.Admin))]
        public IActionResult Edit(int id)
        {

            var productEditVM = _productManager.GetProductByIdForEdit(id);
            if (productEditVM == null)
            {
                return RedirectToAction("Index");
            }

            return View(productEditVM);

        }


        [HttpPost]
        [Authorize(Roles = (SystemRoles.Admin))]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            var product = _productManager.UpdateProduct(productEditVM);
            if (!product)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Authorize(Roles = (SystemRoles.Admin))]
        public IActionResult Delete(int id)
        {
            var product = _productManager.RemoveProduct(id);
            if (!product)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
