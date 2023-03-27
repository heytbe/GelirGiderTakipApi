using Core.API.Entities;
using System.Linq.Expressions;

namespace Data.API.Repositories.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class,IEntityBase,new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> predicate =null, params Expression<Func<TEntity, object>>[] includePredicate);
        Task AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdFindAsync(int id);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePredicate);

    }
}
