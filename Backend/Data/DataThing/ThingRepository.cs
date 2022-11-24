using Backend.Data.Generic;
using Backend.DataAccess;
using Backend.Entities;

namespace Backend.Data.DataThing
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(ThingsContext context) : base(context) { }
    }
}
