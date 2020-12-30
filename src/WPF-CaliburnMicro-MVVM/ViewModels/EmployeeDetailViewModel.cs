using Caliburn.Micro;
using System;
using WPF_CaliburnMicro_MVVM.Messages;
using WPF_CaliburnMicro_MVVM.Models;
using WPF_CaliburnMicro_MVVM.Services;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public class EmployeeDetailViewModel: ViewModelBase
    {

        private readonly IEmployeeService employeeService;

        public EmployeeDetailViewModel(IEmployeeService employeeService)
        {
            if (employeeService == null) throw new ArgumentNullException("employeeService");
            this.employeeService = employeeService;
        }

        public string EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

        public void Back()
        {
            EventAggregator.PublishOnBackgroundThread(new ViewEmployeeList());
        }
        /*
        private void BindEmployeeDetail()
        {
            if (Busy) return;

            Busy = true;

            var task = employeeService.GetEmployeedetail(EmployeeId);

            task.ContinueWith(x =>
            {
                Busy = false;
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(t =>
            {
                var result = t.Result;
                if (result != null)
                {
                    this.Employee = result;
                    Busy = false;
                    return;
                }

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        }*/

        protected override void OnLoadedCore()
        {             
            SubscribeToMessages();
            //BindEmployeeDetail();
        }

    }
}
