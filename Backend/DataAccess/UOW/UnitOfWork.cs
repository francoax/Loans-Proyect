using Backend.Data.DataThing;
using Backend.DataAccess;
using Backend.DataAccess.DataCategory;
using Backend.DataAccess.DataLoan;
using Backend.DataAccess.DataPeople;
using Backend.DataAccess.DataRol;
using Backend.DataAccess.DataUser;

namespace Backend.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThingsContext context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IThingRepository ThingRepository { get; private set; }
        public IPeopleRepository PeopleRepository { get; private set; }
        public ILoansRepository LoansRepository { get; private set; }
        public IUsersRepository UsersRepository { get; private set; }
        public IRolesRepository RolesRepository { get; private set; }
        public UnitOfWork(ThingsContext context)
        {
            this.context = context;
            CategoryRepository = new CategoryRepository(context);
            ThingRepository = new ThingRepository(context);
            PeopleRepository = new PeopleRepository(context);
            LoansRepository = new LoansRepository(context);
            UsersRepository = new UsersRepository(context);
            RolesRepository = new RolesRepository();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
