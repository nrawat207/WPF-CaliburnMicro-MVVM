using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CaliburnMicro_MVVM.Services;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Registries
{
    public class ServiceRegistry: Registry
    {
        public ServiceRegistry()
        {
            For<IEmployeeService>().Use<EmployeeService>();

        }
    }
}
