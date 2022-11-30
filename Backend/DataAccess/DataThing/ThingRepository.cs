using Backend.Data.Generic;
using Backend.DataAccess;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DataThing
{
    public class ThingRepository : GenericRepository<Thing>, IThingRepository
    {
        public ThingRepository(ThingsContext context) : base(context) { }

        public override List<Thing> GetAll()
        {
            return context.Things.Include(t => t.Category).ToList();
        }
        public override Thing? GetById(int id)
        {
            return context.Things.Include(t => t.Category).FirstOrDefault(t => t.Id == id);
        }
    }
}
