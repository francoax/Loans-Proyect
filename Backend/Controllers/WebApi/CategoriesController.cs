using Backend.Data.UOW;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CategoriesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost]
        public ActionResult<Category> Create([FromBody] Category category)
        {
            if (category.Description.IsNullOrEmpty()) return BadRequest("Especifique la descripcion");

            if (uow.CategoryRepository.Exists(category)) return BadRequest("La categoria ya existe");

            var newCategory = new Category
            {
                Description = category.Description
            };
            newCategory = uow.CategoryRepository.Add(newCategory);
            uow.CompleteAsync();
            return Created($"/categories/{newCategory.Id}", newCategory);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var categoryToDelete = uow.CategoryRepository.GetById(id);
            if (categoryToDelete is null) return NotFound("La categoria especificada no existe");
            uow.CategoryRepository.Delete(categoryToDelete);
            uow.CompleteAsync();
            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Category> UpdateDescription(int id, [FromBody]Category category)
        {
            if (category.Description.IsNullOrEmpty()) return BadRequest("Especifique la nueva descripcion");
            var categoryToUpdate = uow.CategoryRepository.GetById(id);
            if (categoryToUpdate is null) return NotFound("La categoria especificada no existe");
            categoryToUpdate.Description = category.Description;
            uow.CompleteAsync();
            return categoryToUpdate;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var categoryRequested = uow.CategoryRepository.GetById(id);
            if (categoryRequested is null) return NotFound("La categoria especificada no fue encontrada");
            return Ok(categoryRequested);
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return uow.CategoryRepository.GetAll();
        }
    }
}
