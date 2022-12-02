using Backend.Data.DataThing;
using Backend.DataAccess.DataCategory;
using Backend.DataAccess.DataLoan;
using Backend.DataAccess.DataPeople;
using Backend.DataAccess.DataRol;
using Backend.DataAccess.DataUser;

namespace Backend.Data.UOW
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IThingRepository ThingRepository { get; }
        IPeopleRepository PeopleRepository { get; }
        ILoansRepository LoansRepository { get; }
        IUsersRepository UsersRepository { get; } 
        IRolesRepository RolesRepository { get; }
        Task CompleteAsync();
        void Complete();
    }
}
