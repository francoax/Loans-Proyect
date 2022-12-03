using AutoMapper;
using Backend.Data.UOW;
using Backend.Dto;
using Backend.Entities;
using Backend.Statics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public PeopleController(
            IUnitOfWork uow,
            IMapper _mapper)
        {
            this.uow = uow;
            this._mapper = _mapper;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Person>> Create([FromBody] PersonForCreationDto personToCreate)
        {
            if (personToCreate.HasAnyPropertyNullOrEmpty()) return BadRequest("Especifique correctamente la persona a crear");
            var _mappedPerson = _mapper.Map<Person>(personToCreate);
            _mappedPerson = uow.PeopleRepository.Add(_mappedPerson);
            await uow.CompleteAsync();
            return Created($"/people/{_mappedPerson.Id}", _mappedPerson);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "user")]
        public async  Task<IActionResult> Delete(int id)
        {
            var personToDelete = uow.PeopleRepository.GetById(id);
            if (personToDelete is null) return BadRequest("Persona no encontrada");
            uow.PeopleRepository.Delete(personToDelete);
            await uow.CompleteAsync();
            return Ok(personToDelete);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<Person>> Update(int id, [FromBody] PersonForModificationDto person)
        {
            var personToModificate = uow.PeopleRepository.GetById(id);
            if (personToModificate is null) return NotFound("Persona no encontrada");
            if (person.HasAnyPropertyNullOrEmpty()) return BadRequest("No debe haber campos vacios o nulos");
            person.Id = id;
            _mapper.Map(person, personToModificate);
            uow.PeopleRepository.Update(personToModificate);
            await uow.CompleteAsync();
            return Ok(personToModificate);
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult<List<Person>> GetAll()
        {
            return uow.PeopleRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "user")]
        public IActionResult GetById(int id)
        {
            var personRequested = uow.PeopleRepository.GetById(id);
            if (personRequested is null) return NotFound();
            return Ok(personRequested);
        }
    }
}
