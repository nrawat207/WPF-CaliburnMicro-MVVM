using System;
using System.Data;

namespace Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public Guid Id { get; private set; }

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.OpenConnection();
            Id = Guid.NewGuid();
        }

        public void Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Commit()
        {
            if (_transaction == null) return;
            _transaction.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        public IDbConnection GetActiveConnection()
        {
            return _connection;
        }

        public IDbTransaction GetActiveTransaction()
        {
            return _transaction;
        }

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                    _transaction.Rollback();
                _connection.Close();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
