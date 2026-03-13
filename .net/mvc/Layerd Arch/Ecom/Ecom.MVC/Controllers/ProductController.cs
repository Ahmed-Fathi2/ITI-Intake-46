using Ecom.BLL.Managers.ProductManager;
using Ecom.BLL.ViewModel.ProductVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Ecom.MVC.Controllers

{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productReadVM = _productManager.GetAllProducts();
              
            return View(productReadVM);
        }



        [HttpGet]
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
        public IActionResult Create()
        {

            var categories = _productManager.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name

            }).ToList();

            var productCreateVM = new ProductCreateVM
            {
                Categories = categories
            };
            return View(productCreateVM);

            return View();
        }


        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid)
            {

                //var categories = _productManager.GetAll().Select(x => new SelectListItem
                //{
                //    Value = x.Id.ToString(),
                //    Text = x.Name
                //}).ToList();

                //productCreateVM.Categories = categories;
                return View(productCreateVM);
            }

            //save image physically at server

            //var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(productCreateVM.Image.FileName);

            //var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Product");

            //var dbFolderPath = Path.Combine("Images", "Product", uniqueFileName);

            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}

            //var filePath = Path.Combine(folderPath, uniqueFileName);

            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    productCreateVM.Image.CopyTo(stream);

            //}

            // save IamgeUrl in db
            //var product = new Product
            //{
            //    Name = productCreateVM.Name,
            //    Description = productCreateVM.Description,
            //    Price = productCreateVM.Price,
            //    Count = productCreateVM.Count,
            //    CategoryId = productCreateVM.CategoryId
            //    //ImageUrl = dbFolderPath

            //};
            productCreateVM.CategoryId = 1;
          _productManager.AddProduct(productCreateVM);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var productEditVM = _productManager.GetProductByIdForEdit(id);
            if (productEditVM == null)
            {
                return RedirectToAction("Index");
            }
            //var categories = _categoryRepository.GetAll().Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.Name

            //}).ToList();

            //var productEditVM = new ProductEditVM
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    Count = product.Count,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category.Name,
            //    Categories = categories
            //};


            return View(productEditVM);

        }


        [HttpPost]
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
        public IActionResult Delete(int id)
        {
            var product = _productManager.RemoveProduct(id);
            if (!product)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //[AcceptVerbs("GET", "POST")]
        //public IActionResult IsNameExist(string name)
        //{
        //    var isNameExist = _productRepository.Any(name);

        //    if (isNameExist)
        //    {
        //        return Json($"Product Name {name} exist");
        //    }
        //    return Json(true);
        //}
    }
}
