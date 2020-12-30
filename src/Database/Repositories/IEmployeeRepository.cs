using Domain;
using System.Collections.Generic;

namespace Database.Repositories
{
    public interface IEmployeeRepository 
    {
        void AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeDetail(int id);
    }
}
