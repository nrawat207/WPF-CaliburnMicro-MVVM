using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPF_CaliburnMicro_MVVM.Models;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public class EmployeeService : ApiServiceBase, IEmployeeService
    {
        public void AddEmployee(EmployeeModel employeeModel)
        {
            Url("employee", "addEmployee").PostJsonAsync    (employeeModel);           
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var result = await Url("employee").GetJsonListAsync();
            return result.Select(MapEmpoyee);
        }

        public async Task<EmployeeModel> GetEmployeedetail(string id)
        {
            var result = await Url("employee",id).GetJsonAsync();
            return MapEmpoyee(result);
        }


        private EmployeeModel MapEmpoyee(dynamic x)
        {
            return new EmployeeModel
            {
                Id = x.id,
                Name = x.name,
                Department = x.department,
                Designation = x.designation,
                DOB = x.dob
            };
        }
    }
}
