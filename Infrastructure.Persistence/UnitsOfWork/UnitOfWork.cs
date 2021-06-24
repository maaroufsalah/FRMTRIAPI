using Application.Interfaces.IRepositories;
using Application.Interfaces.IUnitOfWork;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MainContext _dbContext;
        public UnitOfWork(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Repositories attributs -> UnitOfWork pattern repositories

        private IGenericRepository<Ville> _ville;
        public IGenericRepository<Ville> Ville
        {
            get
            {
                if (_ville is null) _ville = new GenericRepository<Ville>(_dbContext);
                return _ville;
            }
        }
        #endregion

        #region Repositories methods -> UnitOfWork pattern repositories

        public void BeginTransaction()
        {
        }

        public void Commit()
        {
        }

        public void Rollback()
        {
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.SaveChanges();
            //return 1;
        }

        public async Task<int> BulkCompleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.BulkSaveChangesAsync(cancellationToken);
            return 1;
        }

        #endregion Repositories methods -> UnitOfWork pattern repositories

        #region Dispose => Implementing a Dispose method : Microsoft

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Free any other managed objects here.
                _dbContext.Dispose();
            }
            disposed = true;
        }

        #endregion Dispose => Implementing a Dispose method : Microsoft
    }
}
