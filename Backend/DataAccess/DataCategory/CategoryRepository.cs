using Backend.Data.Generic;
using Backend.Entities;

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

        public override List<Category> GetAll()
        {
            return new List<Category>
                        {
                            new Category { Id = 1, Description = "Herramientas"},
                            new Category { Id = 2, Description = "Entretenimiento"},
                            new Category { Id = 3, Description = "Cocina"},
                            new Category { Id = 4, Description = "Tecnologia"},
                            new Category { Id = 5, Description = "Deportes"},
                        };
        }
    }
}
