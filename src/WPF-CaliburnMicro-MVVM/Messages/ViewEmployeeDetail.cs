using WPF_CaliburnMicro_MVVM.Models;

namespace WPF_CaliburnMicro_MVVM.Messages
{
    public class ViewEmployeeDetail
    {
        public ViewEmployeeDetail(EmployeeModel selectedEmployee)
        {
            SelectedEmployee = selectedEmployee;
        }
        public EmployeeModel SelectedEmployee{ get; set; }
    }
}
