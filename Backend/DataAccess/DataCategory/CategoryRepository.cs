using Backend.Data.Generic;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.DataCategory
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ThingsContext context) : base(context) { }

        public Category? GetByDesc(string desc)
        {
            return context.Categories.Where(c => c.Description == desc).FirstOrDefault();
        }

        public bool Exists(Category category)
        {
            return context.Categories.Where((c) => c.Description == category.Description).Any();
        }

        public List<Category> GetCategoriesWithThings()
        {
            return context.Categories.Include(c => c.Things).ToList();
        }
    }
}
