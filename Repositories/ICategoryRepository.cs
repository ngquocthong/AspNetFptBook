using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category c);
        void DeleteCategory(Category c);
        Category GetCateByID(int id);
        void UpdateCate(Category temp);
    }
}
