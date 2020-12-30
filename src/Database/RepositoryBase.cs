using System;
using System.Data;

namespace Database
{
    public abstract class RepositoryBase
    {
        protected readonly IDbConnection Connection;
        protected readonly IDbTransaction ActiveTransaction;
        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            ActiveTransaction = unitOfWork.GetActiveTransaction();
            Connection = unitOfWork.GetActiveConnection();
        }
    }
}
