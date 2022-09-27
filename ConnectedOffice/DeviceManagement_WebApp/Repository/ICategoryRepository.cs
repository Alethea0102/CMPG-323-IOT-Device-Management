using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public interface lCategoryRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();
        Category getCategoryById(Guid? id);
        Guid newGuId(Category category);
        Guid getCategoryId(Category categoty);
        bool categoryExists(Guid id);
    }
}
