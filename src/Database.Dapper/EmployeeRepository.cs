using Dapper;
using Database.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Dapper
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void AddEmployee(Employee employee)
        {
            Connection.Execute(Sql.Employee.Insert, employee, ActiveTransaction);
        }

        public Employee GetEmployeeDetail(int id)
        {
            var sql = $"{Sql.Employee.SelectById}" + " AND Id = @id";
            return Connection.Query<Employee>(sql, new { id }, ActiveTransaction).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {            
            return Connection.Query<Employee>(Sql.Employee.Select,ActiveTransaction);
        }
    }
}
