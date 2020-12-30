using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_CaliburnMicro_MVVM.Messages;
using WPF_CaliburnMicro_MVVM.Models;
using WPF_CaliburnMicro_MVVM.Services;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public class EmployeeListViewModel : ViewModelBase
    {
        private readonly IEmployeeService employeeService;
        private EmployeeModel selectedEmployee;
        public EmployeeListViewModel(IEmployeeService employeeService)
        {
            if (employeeService == null) throw new ArgumentNullException("employeeService");
            this.employeeService = employeeService;
            this.Employees = new BindableCollection<EmployeeModel>();
        }

        public EmployeeModel SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value == selectedEmployee) return;

                selectedEmployee = value;
                NotifyOfPropertyChange(() => SelectedEmployee);               
            }
        }
        public IObservableCollection<EmployeeModel> Employees { get; set; }

        private void BindEmployeeList()
        {
            if (Busy) return;

            Busy = true;

            var task = employeeService.GetEmployees();

            task.ContinueWith(x =>
            {
                Busy = false;
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(t =>
            {
                var result = t.Result;
                if (result != null)
                {
                    Employees.Clear();
                    foreach (var item in result)
                    {
                        Employees.Add(item);
                    }                    
                    Busy = false;
                    return;
                }

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        }

        public void ViewEmployee()
        {
            EventAggregator.PublishOnBackgroundThread(new ViewEmployeeDetail(SelectedEmployee));
        }

        protected override void OnLoadedCore()
        {            
            SubscribeToMessages();
            BindEmployeeList();
        }
    }
}
