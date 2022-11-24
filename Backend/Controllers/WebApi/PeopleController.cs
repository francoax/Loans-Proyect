using Backend.Data.UOW;
using Backend.Dto;
using Backend.Entities;
using Backend.Services.PeopleService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.WebApi
{
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IPeopleService service;
        public PeopleController(IUnitOfWork uow, IPeopleService service)
        {
            this.uow = uow;
            this.service = service;
        }

        [HttpPost]
        public ActionResult<Person> Create([FromBody]PersonToCreateDto personToCreate)
        {
            if (!service.HasCorrectAttributes(personToCreate)) return BadRequest("Especifique correctamente la persona a crear");
            var newPerson = new Person
            {
                Name = personToCreate.Name,
                PhoneNumber = personToCreate.PhoneNumber,
                Email = personToCreate.Email,
            };
            newPerson = uow.PeopleRepository.Add(newPerson);
            uow.CompleteAsync();
            return Created($"/people/{newPerson.Id}", newPerson);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var personToDelete = uow.PeopleRepository.GetById(id);
            if(personToDelete is null) return BadRequest("Persona no encontrada");
            uow.PeopleRepository.Delete(personToDelete);
            uow.CompleteAsync();
            return NoContent();
        }
        
        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return uow.PeopleRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var personRequested = uow.PeopleRepository.GetById(id);
            if(personRequested is null) return NotFound();
            return Ok(personRequested);
        }
    }
}
