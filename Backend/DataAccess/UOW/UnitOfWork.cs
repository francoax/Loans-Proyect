using Backend.Data.DataThing;
using Backend.DataAccess;
using Backend.DataAccess.DataCategory;
using Backend.DataAccess.DataPeople;

namespace Backend.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThingsContext context;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IThingRepository ThingRepository { get; private set; }
        public IPeopleRepository PeopleRepository { get; private set; }

        public UnitOfWork(ThingsContext context)
        {
            this.context = context;
            CategoryRepository = new CategoryRepository(context);
            ThingRepository = new ThingRepository(context);
            PeopleRepository = new PeopleRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
