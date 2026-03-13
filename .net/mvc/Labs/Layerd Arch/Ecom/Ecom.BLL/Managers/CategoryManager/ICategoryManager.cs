using Ecom.BLL.ViewModel.CategoryVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.BLL.Managers.CategoryManager
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryReadVM> GetAllCategories();

        CategoryReadVM? GetCategoryById(int id);

        void AddCategory(CategoryCreateVM categoryCreateVM);


        bool UpdateCategory(CategoryEditVM categoryEditVM);

        bool RemoveCategory(int id);    








    }
}
