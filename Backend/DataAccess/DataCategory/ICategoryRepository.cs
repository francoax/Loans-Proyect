using Backend.Data.Generic;
using Backend.Entities;

namespace Backend.DataAccess.DataCategory
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetByDesc(string desc);

        bool Exists(Category category);

        List<Category> GetCategoriesWithThings();

        void AddMany(List<Category> categories);
    }
}
