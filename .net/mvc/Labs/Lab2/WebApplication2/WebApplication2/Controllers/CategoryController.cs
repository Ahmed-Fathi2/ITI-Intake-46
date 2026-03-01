using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Entities;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        private AppDbContext dbContext = new AppDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categoryReadVM = dbContext.Categories
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
            var category = dbContext.Categories
                            .FirstOrDefault(x => x.Id == id);

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

            dbContext.Add(category);
            dbContext.SaveChanges();

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = dbContext.Categories.FirstOrDefault(x => x.Id == id);
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
            var category = dbContext.Categories.FirstOrDefault(x => x.Id == categoryEditVM.Id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            category.Name = categoryEditVM.Name;
            category.Description = categoryEditVM.Description;
           

            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }
            dbContext.Remove(category);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
