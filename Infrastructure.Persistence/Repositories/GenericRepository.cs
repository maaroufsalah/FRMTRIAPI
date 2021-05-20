using Application.Interfaces.IRepositories;
using Infrastructure.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            private readonly MainContext _dbContext;
            private readonly DbSet<TEntity> _dbSet;
            public GenericRepository(MainContext dbContext)
            {
                _dbContext = dbContext;
                _dbSet = dbContext.Set<TEntity>();
                _dbContext.ChangeTracker.LazyLoadingEnabled = false;
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            }

            #region Get data
            public virtual async Task<TEntity> GetByIdAsync(int id)
            {
                return await _dbSet.FindAsync(id);
            }
            public async Task<IReadOnlyList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                return await Query(orderBy: orderBy).ToListAsync();
            }
            public async Task<IReadOnlyList<TDest>> GetAllAsync<TDest>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TDest>> selector)
            {
                return await Query(orderBy: orderBy).Select(selector).ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> GetAllPagedReponseAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                return await Query(orderBy: orderBy)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes).ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> GetAllPagedReponseAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
            }

            public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                return await Query(orderBy: orderBy)
                    .Where(predicate)
                    .AsNoTracking()
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntityMapper>> FindAsync<TEntityMapper>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntityMapper>> selector = null)
            {
                return await Query(orderBy: orderBy)
                    .Where(predicate)
                    .AsNoTracking()
                    .Select(selector)
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> FindPagedResponseAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                return await Query(orderBy: orderBy)
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes)
                    .Where(predicate)
                    .AsNoTracking()
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntityMapper>> FindAsync<TEntityMapper>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Expression<Func<TEntity, TEntityMapper>> selector = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes)
                    .Where(predicate)
                    .AsNoTracking()
                    .Select(selector)
                    .ToListAsync();
            }
            public async Task<IReadOnlyList<TEntity>> FindPagedResponseAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes)
                    .Where(predicate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
            }
            public async Task<int> FindCountAsync(Expression<Func<TEntity, bool>> predicate)
            {
                return await _dbSet
                    .Where(predicate)
                    .AsNoTracking()
                    .CountAsync();
            }

            public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                return await Query(orderBy: orderBy)
                    .Where(predicate)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return await Query(orderBy: orderBy, includes: includes)
                    .Where(predicate)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                return Query(orderBy: orderBy, includes: includes)
                    .Where(predicate)
                    .AsNoTracking()
                    .FirstOrDefault();
            }
            #endregion

            #region CUD data
            public async void AddAsync(TEntity entity)
            {
                await _dbSet.AddAsync(entity);
            }
            public void UpdateAsync(TEntity entity)
            {
                AttachIfNot(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            public void Delete2(TEntity entity)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                //_dbContext.BulkSaveChanges();
            }

            public void DeleteAsync(TEntity entity)
            {
                _dbSet.Remove(entity);
                //_dbContext.BulkSaveChanges();
            }
            public async void AddRangeAsync(IEnumerable<TEntity> entities)
            {
                await _dbSet.AddRangeAsync(entities);
            }
            public void UpdateRangeAsync(IEnumerable<TEntity> entities)
            {
                foreach (var entity in entities)
                {
                    AttachIfNot(entity);
                    _dbContext.Entry(entity).State = EntityState.Modified;
                }
            }
            public void DeleteRangeAsync(IEnumerable<TEntity> entities)
            {
                _dbSet.RemoveRange(entities);
            }
            #endregion

            #region Helpers
            private void Attach(TEntity entity)
            {
                _dbSet.Attach(entity);
            }
            private void AttachIfNot(TEntity entity)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached || _dbContext.Entry(entity).State == EntityState.Unchanged)
                {
                    Attach(entity);
                }
            }
            private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
            {
                IQueryable<TEntity> query = _dbSet;
                if (predicate != null)
                    query.Where(predicate);
                if (orderBy != null)
                    orderBy(query);
                return query;
            }
            private IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
            {
                IQueryable<TEntity> query = _dbSet;
                if (predicate != null)
                    query.Where(predicate);
                foreach (Expression<Func<TEntity, object>> include in includes)
                {
                    query = query.Include(include);
                }
                if (orderBy != null)
                    return orderBy(query);
                else
                    return query;
            }

            /// <summary>
            /// Get connection string
            /// </summary>
            /// <returns></returns>
            protected string ConnectionString() => _dbContext.Database.GetDbConnection().ConnectionString;
            /// <summary>
            /// Generate new connection based on connection string
            /// </summary>
            /// <returns></returns>
            private SqlConnection SqlConnection()
            {
                return new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString);
            }
            /// <summary>
            /// Open new connection and return it for use
            /// </summary>
            /// <returns></returns>
            protected IDbConnection CreateConnection()
            {
                var conn = SqlConnection();
                conn.Open();
                return conn;
            }
            #endregion
        }
}
