using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CateroryRepository : ICategoryRepository
    {
        public List<Category> GetCategories() => CategoryDAO.GetCategories();
        public void AddCategory(Category c) => CategoryDAO.SaveCategory(c);
        public void DeleteCategory(Category c) => CategoryDAO.DeleteCategory(c);

        public Category GetCateByID(int id) => CategoryDAO.FindCategoryById(id);

        public void UpdateCate(Category c) => CategoryDAO.UpdateCategory(c);
    }
}
