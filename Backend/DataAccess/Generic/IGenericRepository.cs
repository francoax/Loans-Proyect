﻿using Backend.Entities;

namespace Backend.Data.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        TEntity GetById(int id);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}
