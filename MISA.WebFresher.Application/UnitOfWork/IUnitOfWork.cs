using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher.Application
{
    /// <summary>
    /// Interface unit of work
    /// </summary>
    /// Created by: dtthanh (25/9/2023)
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }

        DbTransaction? Transaction { get; }

        void BeginTransaction();

        Task BeginTransactionAsync();

        void Commit();

        Task CommitAsync();

        void RollBack();

        Task RollBackAsync();
    }
}
