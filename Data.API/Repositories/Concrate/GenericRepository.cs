using Core.API.Entities;
using Data.API.Context;
using Data.API.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.API.Repositories.Concrate
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IEntityBase, new()
    {

        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> Table { get => _context.Set<TEntity>(); }

        public async Task AddAsync(TEntity entity)
        {
           await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includePredicate)
        {
            IQueryable<TEntity> query = Table;
            if(predicate != null)
            {
               query = query.Where(predicate);
            }

            if (includePredicate.Any())
            {
                foreach (var item in includePredicate)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePredicate)
        {
            IQueryable<TEntity> query = Table;

            if (includePredicate.Any())
            {
                foreach (var item in includePredicate)
                {
                    query = query.Include(item);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            

            return await query.FirstAsync();
        }

        public async Task<TEntity> GetByIdFindAsync(int id)
        {
            var findEntity = await Table.FindAsync(id);
            if(findEntity == null)
            {

            }
            else
            {
                _context.Entry(findEntity).State = EntityState.Detached;
            }

            return findEntity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
