﻿using Backend.DataAccess;
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

        public TEntity Delete(TEntity entity)
        {
            var entityDeleted = dbSet.Remove(entity);
            return entityDeleted.Entity;
        }

        public void Update(TEntity entity)
        {
           dbSet.Update(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            List<TEntity> entities = new List<TEntity>();
            entities = dbSet.ToList();
            return entities;
        }

        public virtual TEntity? GetById(int id)
        {
            return dbSet.FirstOrDefault(e => e.Id == id);
        }
    }
}
