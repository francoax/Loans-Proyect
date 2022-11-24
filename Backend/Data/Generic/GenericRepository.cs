using Backend.DataAccess;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        protected ThingsContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ThingsContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            var newEntity = dbSet.Add(entity);
            return newEntity.Entity;
        }

        public TEntity Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
