using AutoMapper;
using Backend.Data.UOW;
using Backend.Dto;
using Backend.Entities;
using Backend.Statics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public LoansController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> Create([FromBody]LoanForCreationDto loanToCreate)
        {
            try
            {
                var loanMapped = mapper.Map<Loan>(loanToCreate);
                loanMapped.Date = DateTime.UtcNow;
                loanMapped.Status = "Prestado";
                uow.LoansRepository.Add(loanMapped);
                await uow.CompleteAsync();
                return Created($"/loans/{loanMapped.Id}", loanMapped);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Thing or Person not found");
            }
            
        }


        [HttpGet]
        public ActionResult<List<Loan>> GetAll()
        {
            var loans = uow.LoansRepository.GetAll();
            if (loans.IsNullOrEmpty())
                return NotFound("You don't have any loans yet.");

            var loansList = mapper.Map<List<LoanDto>>(loans);
            return Ok(loansList);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var loanToDelete = uow.LoansRepository.GetById(id);
            if (loanToDelete is null)
                return NotFound("El prestamo solicitado no fue encontrado.");

            uow.LoansRepository.Delete(loanToDelete);
            uow.CompleteAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Loan> GetById(int id)
        {
            var loan = uow.LoansRepository.GetById(id);
            if (loan is null) 
                return NotFound("El prestamo solicitado no fue encontrado.");

            return Ok(loan);
        }
    }
}
