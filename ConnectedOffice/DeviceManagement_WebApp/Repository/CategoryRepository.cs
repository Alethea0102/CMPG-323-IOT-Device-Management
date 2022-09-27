using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, lCategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public bool categoryExists(Guid id)
        {
            return _context.Category.Any(entity => entity.CategoryId == id);
        }

        public Category getCategoryById(Guid? id)
        {
            var category = _context.Category.FirstOrDefault(m => m.CategoryId == id);

            return category;
        }

        public Guid getCategoryId(Category categoty)
        {
            return categoty.CategoryId;
        }

        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(Category => Category.DateCreated).FirstOrDefault();
        }

        public Guid newGuId(Category category)
        {
           return category.CategoryId = Guid.NewGuid();
        }
    }
}
