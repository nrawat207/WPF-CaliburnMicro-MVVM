using Caliburn.Micro;
using System;
using WPF_CaliburnMicro_MVVM.Messages;
using WPF_CaliburnMicro_MVVM.Models;
using WPF_CaliburnMicro_MVVM.Services;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly IEmployeeService employeeService;
        private EmployeeModel employee;
        public AddEmployeeViewModel(IEmployeeService employeeService)
        {
            if (employeeService == null) throw new ArgumentNullException("employeeService");
            this.employeeService = employeeService;
            this.Employee = new EmployeeModel();
        }
        protected override void OnLoadedCore()
        {
            SubscribeToMessages();
        }
        public EmployeeModel Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                NotifyOfPropertyChange(() => Employee);                
            }
        }

        public void Add()
        {
            this.employeeService.AddEmployee(this.Employee);
            EventAggregator.PublishOnBackgroundThread(new ActivateUserMessageScreen(
                                string.Format("Employee Added Successfully!"),
                                UserMessageType.Information));            
        }
    }
}
