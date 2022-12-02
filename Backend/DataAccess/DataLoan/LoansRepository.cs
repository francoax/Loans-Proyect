using Backend.Data.Generic;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess.DataLoan
{
    public class LoansRepository : GenericRepository<Loan>, ILoansRepository
    {
        public LoansRepository(ThingsContext context) : base(context)
        {

        }
        public override List<Loan> GetAll()
        {
            return context.Loans.Include(l => l.Person).Include(l => l.Thing).ToList();
        }
        public List<Loan> GetLoansByPerson(int PersonId)
        {
            return context.Loans.Include(l => l.Person).Where(l => l.Person.Id == PersonId).ToList();
        }
        public override Loan? GetById(int id)
        {
            return context.Loans.Include(l => l.Person).Include(l => l.Thing).FirstOrDefault(l => l.Id == id);
        }
    }
}
