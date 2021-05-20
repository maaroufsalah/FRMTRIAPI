using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IReadOnlyList<TDest>> GetAllAsync<TDest>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TDest>> selector);
        Task<IReadOnlyList<TEntity>> GetAllPagedReponseAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> GetAllPagedReponseAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IReadOnlyList<TEntityMapper>> FindAsync<TEntityMapper>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntityMapper>> selector = null);
        Task<IReadOnlyList<TEntity>> FindPagedResponseAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntityMapper>> FindAsync<TEntityMapper>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntityMapper>> selector = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> FindPagedResponseAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<int> FindCountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        void AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void Delete2(TEntity entity);
        void DeleteAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void UpdateRangeAsync(IEnumerable<TEntity> entities);
        void DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
