using Backend.Data.Generic;
using Backend.Entities;

namespace Backend.DataAccess.DataCategory
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ThingsContext context) : base(context) { }

        public Category GetByDesc(string desc)
        {
            return (Category) context.Categories.Where(c => c.Description == desc);
        }
    }
}
