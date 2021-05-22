using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories attributs -> UnitOfWork pattern repositories

        public IGenericRepository<Ville> Ville { get; }


        #endregion Repositories attributs -> UnitOfWork pattern repositories

        #region Repositories methods -> UnitOfWork pattern repositories

        void BeginTransaction();

        void Commit();

        void Rollback();

        Task<int> CompleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<int> BulkCompleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        #endregion Repositories methods -> UnitOfWork pattern repositories
    }
}
