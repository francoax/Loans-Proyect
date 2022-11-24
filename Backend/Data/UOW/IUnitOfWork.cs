using Backend.Data.DataThing;
using Backend.DataAccess.DataCategory;

namespace Backend.Data.UOW
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IThingRepository ThingRepository { get; }

        int CompleteAsync();
    }
}
