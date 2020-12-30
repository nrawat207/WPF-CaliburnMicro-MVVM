using Database;
using Database.Dapper;
using Database.Repositories;
using StructureMap;

namespace WebApi.Infrastructure
{
    public class RepositoryRegistry:Registry
    {
        public RepositoryRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<IConnectionFactory>().Use<SqlConnectionFactory>();
            For<IEmployeeRepository>().Use<EmployeeRepository>();
        }
    }
}