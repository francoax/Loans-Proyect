using Backend.Data.DataThing;
using Backend.DataAccess.DataCategory;
using Backend.DataAccess.DataPeople;

namespace Backend.Data.UOW
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IThingRepository ThingRepository { get; }
        IPeopleRepository PeopleRepository { get; }
        int CompleteAsync();
    }
}
