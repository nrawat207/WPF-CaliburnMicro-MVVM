using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CaliburnMicro_MVVM.Models;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeModel employee);
        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeedetail(string id);
    }
}
