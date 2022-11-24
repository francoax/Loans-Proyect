using Backend.Data.DataThing;
using Backend.DataAccess;
using Backend.DataAccess.DataCategory;

namespace Backend.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThingsContext context;
        public ICategoryRepository CategoryRepository { get; private set; }

        public IThingRepository ThingRepository { get; private set; }

        public UnitOfWork(ThingsContext context)
        {
            this.context = context;
            CategoryRepository = new CategoryRepository(context);
            ThingRepository = new ThingRepository(context);
        }

        public int CompleteAsync()
        {
            return context.SaveChanges();
        }
    }
}
