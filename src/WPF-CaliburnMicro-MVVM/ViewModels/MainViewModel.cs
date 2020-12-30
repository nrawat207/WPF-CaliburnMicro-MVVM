using Caliburn.Micro;
using System;
using WPF_CaliburnMicro_MVVM.Messages;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public class MainViewModel: Conductor<IScreen>.Collection.OneActive
    , IHandle<ViewEmployeeDetail>
    , IHandle<ActivateUserMessageScreen>
    , IHandle<ViewEmployeeList>
    {
        public readonly Infrastructure.Factories.IViewModelFactory viewModelFactory;
        private readonly IEventAggregator eventAggregator;
        private AddEmployeeViewModel addEmployeeView;
        private EmployeeListViewModel employeeListView;
        private EmployeeDetailViewModel employeeDetailView;

        public MainViewModel(Infrastructure.Factories.IViewModelFactory viewModelFactory, IEventAggregator eventAggregator)
        {
            if (viewModelFactory == null) throw new ArgumentNullException("ViewModelFactory");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");

            this.viewModelFactory = viewModelFactory;
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);

            ApplicationVersion = string.Format("Version {0}", GetApplicationVersion());
            addEmployeeView = this.viewModelFactory.Create<AddEmployeeViewModel>();
            ActivateItem(addEmployeeView);

        }

        public string ApplicationVersion { get; set; }

        public void ActivateAddEmployeeView()
        { 
            addEmployeeView = this.viewModelFactory.Create<AddEmployeeViewModel>();
            ActivateItem(addEmployeeView);
        }

        public void ActivateEmployeeListView()
        {
            employeeListView = this.viewModelFactory.Create<EmployeeListViewModel>();
            ActivateItem(employeeListView);
        }

        public void Handle(ActivateUserMessageScreen message)
        {            
            ShowUserMessageScreen(message.Message, message.Type);
        }

        private void ShowUserMessageScreen(string message, UserMessageType type)
        {
            var screen = viewModelFactory.Create<UserMessageViewModel>();
            if (screen != null)
            {
                screen.Message = message;
                screen.SetMessageType(type);
            }
            ActivateItem(screen);
        }

        public void Handle(ViewEmployeeDetail message)
        {
            employeeDetailView = this.viewModelFactory.Create<EmployeeDetailViewModel>();
            employeeDetailView.Employee = message.SelectedEmployee;
            ActivateItem(employeeDetailView);
        }

        public void Handle(ViewEmployeeList message)
        {
            ActivateEmployeeListView();
        }

        public void ExitApplication()
        {            
            ActiveItem.Deactivate(true);
            TryClose();
        }

       

        private string GetApplicationVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            return string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

       
    }
}
