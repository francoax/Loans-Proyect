using Backend.Entities;

namespace Backend.Data.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
        List<TEntity> GetAll();
    }
}
