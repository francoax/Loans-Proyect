using Backend.Data.UOW;
using Grpc.Core;

namespace Backend.Protos
{
    public class GrpcProtoLoanService : ProtoLoanService.ProtoLoanServiceBase
    {
        private readonly IUnitOfWork uow;

        public GrpcProtoLoanService(
            IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public override async Task<LoanResponse> LoanReturned(LoanRequest request, ServerCallContext context)
        {
            var loan = uow.LoansRepository.GetById(request.Id);
            if (loan is null) 
                return new LoanResponse { Loan = new LoanRpc(), Success = false };
            if(loan.Status.Equals("Devuelto"))
                return new LoanResponse { Loan = new LoanRpc(), Success = false };

            loan.Status = "Devuelto";
            loan.ReturnDate = DateTime.UtcNow;

            uow.LoansRepository.Update(loan);
            await uow.CompleteAsync();

            return new LoanResponse
            {
                Loan = new LoanRpc
                {
                    ReturnDate = loan.ReturnDate.ToString(),
                    Status = loan.Status,
                    Person = loan.Person.Name,
                    Thing = loan.Thing.Description
                },
                Success = true
            };
        }
    }
}