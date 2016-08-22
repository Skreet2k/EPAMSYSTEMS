using Kharkovskiy_Alexander_Task10_ORM_.DateModel;

namespace Kharkovskiy_Alexander_Task10_ORM_
{
    public interface IOrmRepository<TEntity>
    {
        TableModel TableModel { get; set; }
        TEntity GetById(string primaryKey);
        IOrmRepository<TEntity> Add(TEntity entity);
        IOrmRepository<TEntity> Remove(string primaryKey);
        IOrmRepository<TEntity> Update(string primaryKey, TEntity entity);
    }
}