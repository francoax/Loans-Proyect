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

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
           dbSet.Update(entity);
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> entities = new List<TEntity>();
            entities = dbSet.ToList();
            return entities;
        }

        public TEntity? GetById(int id)
        {
            return dbSet.FirstOrDefault(e => e.Id == id);
        }

    }
}
