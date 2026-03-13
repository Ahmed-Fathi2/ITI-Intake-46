using Ecom.BLL.Managers.CategoryManager;
using Ecom.BLL.ViewModel.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Ecom.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categoryReadVM = _categoryManager.GetAllCategories();
               
            return View(categoryReadVM);
        }



        [HttpGet]
        public IActionResult GetById(int id)
        {
            var categoryReadVM = _categoryManager.GetCategoryById(id);

            if (categoryReadVM is null)
            {
                return RedirectToAction("Index");
            }


            return View(categoryReadVM);

        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {

           _categoryManager.AddCategory(categoryCreateVM);  
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var categoryEditVM = _categoryManager.GetCategoryById(id);
            if (categoryEditVM is  null)
            {
                return RedirectToAction("Index");
            }

            return View(categoryEditVM);

        }


        [HttpPost]
        public IActionResult Edit(CategoryEditVM categoryEditVM)
        {
            var category = _categoryManager.UpdateCategory(categoryEditVM);
            if (!category)
            {
                return RedirectToAction("Index"); // Assume NotFound
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryManager.RemoveCategory(id);
            if (!category)
            {
                return RedirectToAction("Index"); // Assume NotFound
            }

            return RedirectToAction("Index");
        }
    }
}
