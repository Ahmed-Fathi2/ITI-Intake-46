using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;
using WebApplication2.Repositories.CategoryRepository;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categoryReadVM = _categoryRepository.GetAll()
                .Select(x => new CategoryReadVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description

                }).ToList();

            return View(categoryReadVM);
        }



        [HttpGet]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category is null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var categoryReadDetailsVM = new CategoryReadVM
                {
                    Id= category.Id,
                    Name = category.Name,
                    Description = category.Description
                
                };
                return View(categoryReadDetailsVM);

            }
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {

            var category = new Category
            {
                Name = categoryCreateVM.Name,
                Description = categoryCreateVM.Description
              

            };

            _categoryRepository.Insert(category);
            _categoryRepository.Save();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
         

            var categoryEditVM = new CategoryEditVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
               
            };


            return View(categoryEditVM);

        }


        [HttpPost]
        public IActionResult Edit(CategoryEditVM categoryEditVM)
        {
            var category = _categoryRepository.GetById(categoryEditVM.Id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            category.Name = categoryEditVM.Name;
            category.Description = categoryEditVM.Description;


            _categoryRepository.Save();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
