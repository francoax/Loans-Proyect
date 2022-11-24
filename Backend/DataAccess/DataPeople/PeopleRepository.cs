using Backend.Data.Generic;
using Backend.Entities;

namespace Backend.DataAccess.DataPeople
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(ThingsContext context) : base(context)
        {
        }
    }
}
