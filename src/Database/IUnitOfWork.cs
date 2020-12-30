using System;
using System.Data;

namespace Database
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        void Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        IDbConnection GetActiveConnection();
        IDbTransaction GetActiveTransaction();
    }
}
