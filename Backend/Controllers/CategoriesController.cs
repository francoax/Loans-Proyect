using AutoMapper;
using Backend.Data.UOW;
using Backend.Dto;
using Backend.Entities;
using Backend.Statics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;

        public CategoriesController(
            IUnitOfWork uow,
            IMapper mapper
            )
        {
            this.uow = uow;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] CategoryForCreationDto category)
        {
            if (category.Description.IsNullOrEmpty()) return BadRequest("Especifique la descripcion");
            if (uow.CategoryRepository.GetByDesc(category.Description) is not null) return BadRequest("La categoria ya existe");
            var _mappedCategory = _mapper.Map<Category>(category);
            uow.CategoryRepository.Add(_mappedCategory);
            await uow.CompleteAsync();
            return Created($"/categories/{_mappedCategory.Id}", _mappedCategory);

        }

        [HttpPost("default")]
        public async Task<ActionResult> CreateCategories([FromBody] CategoryForCreationDto[] categories)
        {
            var currentCategories = uow.CategoryRepository.GetAll();
            foreach (var cat in currentCategories)
            {
                foreach (var tocat in categories)
                {
                    if (cat.Description.Equals(tocat.Description))
                    {
                        return BadRequest($"La cateogoria {tocat.Description} ya existe");
                    }
                }
            }
            if (categories.IsNullOrEmpty()) return BadRequest("Especifique las categorias a crear.");
            foreach(var category in categories)
            {
                if(category.Description.IsNullOrEmpty()) return BadRequest("No debe haber descripciones vacias");
            }
            var _mappedCategories = _mapper.Map<List<Category>>(categories);
            uow.CategoryRepository.AddMany(_mappedCategories);
            await uow.CompleteAsync();
            return Ok("Categorias creadas");

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var categoryToDelete = uow.CategoryRepository.GetById(id);
            if (categoryToDelete is null) return NotFound("La categoria especificada no existe");
            uow.CategoryRepository.Delete(categoryToDelete);
            await uow.CompleteAsync();
            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Category>> UpdateDescription(int id, [FromBody] Category category)
        {
            if (category.Description.IsNullOrEmpty()) return BadRequest("Especifique la nueva descripcion");
            var categoryToUpdate = uow.CategoryRepository.GetById(id);
            if (categoryToUpdate is null) return NotFound("La categoria especificada no existe");
            categoryToUpdate.Description = category.Description;
            await uow.CompleteAsync();
            return Ok(categoryToUpdate);
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
            var categories = uow.CategoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("things")]
        public ActionResult<List<Category>> GetCategoriesWithThings()
        {
            return Ok(uow.CategoryRepository.GetCategoriesWithThings());
        }
    }
}
