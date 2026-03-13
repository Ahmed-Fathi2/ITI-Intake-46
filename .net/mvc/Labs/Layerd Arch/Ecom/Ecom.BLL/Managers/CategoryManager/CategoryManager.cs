using Ecom.BLL.ViewModel.CategoryVM;
using Ecom.DAL.Repositories.UnitOfWork;
using WebApplication2.Ecom.DAL.Models;

namespace Ecom.BLL.Managers.CategoryManager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryReadVM> GetAllCategories()
        {
            // Call DAL 
            // Mapping

            var categories = _unitOfWork.CategoryRepository.GetAll()
                .Select(c => new CategoryReadVM
                {

                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                });

            return categories;


        }

        public CategoryReadVM? GetCategoryById(int id)
        {
            var category= _unitOfWork.CategoryRepository.GetById(id);   
            if(category == null)
            {
                return null;
            }

            return new CategoryReadVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
        }
        public void AddCategory(CategoryCreateVM categoryCreateVM)
        {
            //Mapping

            var category = new Category
            {
                Name = categoryCreateVM.Name,
                Description = categoryCreateVM.Description,

            };
            _unitOfWork.CategoryRepository.Insert(category);
            _unitOfWork.Save();

        }


        public bool RemoveCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category == null)
            {
                return false;
            }

            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
            return true;


        }

        public bool UpdateCategory(CategoryEditVM categoryEditVM)
        {

            var category = _unitOfWork.CategoryRepository.GetById(categoryEditVM.Id);
            if (category == null)
            {
                return false;
            }

            category.Name = categoryEditVM.Name;
            category.Description = categoryEditVM.Description;

            _unitOfWork.Save();
            return true;

        }
    }
}
