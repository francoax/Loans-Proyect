using Backend.Data.UOW;
using Backend.DataAccess;
using Backend.DataAccess.DataCategory;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers.WebApi
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CategoriesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost]
        public ActionResult<Category> Create([FromBody]string description)
        {
            if (description.IsNullOrEmpty()){
                return BadRequest("Especifique la descripcion");
            }
            if (uow.CategoryRepository.GetByDesc(description).Description == description)
            {
                return BadRequest("Ya existe una categoria con esa descripcion");
            }
            var newCategory = new Category { Description = description };
            uow.CategoryRepository.Add(newCategory);

            uow.CompleteAsync();

            return Created($"/categories/{newCategory.Id}", newCategory);
        }
    }
}
