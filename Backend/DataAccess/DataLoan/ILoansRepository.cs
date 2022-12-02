using Backend.Data.Generic;
using Backend.Entities;

namespace Backend.DataAccess.DataLoan
{
    public interface ILoansRepository : IGenericRepository<Loan>
    {
        List<Loan> GetLoansByPerson(int id);
    }
    
}
