using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models.DataAccessLayer;
using SuperMarket.Models.Entity;

namespace SuperMarket.Models.BusinessLogicLayer
{
    class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        public void DeleteCategory(int categoryId)
        {
            categoryDAL.DeleteCategory(categoryId);
        }

        public Category GetCategoryById(int id)
        {
            return categoryDAL.GetACategory(id);
        }

        public List<Category> GetAllCategories()
        {
            return categoryDAL.GetCategories();
        }

        public void AddCategory(string name)
        {
            categoryDAL.AddCategory(name);
        }

        public Category GetCategory(string name)
        {
            List<Category> categories = categoryDAL.GetCategories();
            foreach (Category category in categories)
            {
                if (category.Name.ToLower() == name.ToLower())
                {
                    return category;
                }
            }
            return null;
        }

        public Category GetCategory(int id)
        {
            return categoryDAL.GetACategory(id);
        }

        public void UpdateCategory(int Id, string Name)
        {
            categoryDAL.UpdateCategory(Id, Name);
        }
    }
}
