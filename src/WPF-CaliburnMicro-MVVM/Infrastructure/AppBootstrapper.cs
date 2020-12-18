using Caliburn.Micro;
using log4net.Config;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WPF_CaliburnMicro_MVVM.Infrastructure.Registries;
using WPF_CaliburnMicro_MVVM.Services;
using WPF_CaliburnMicro_MVVM.ViewModels;

namespace WPF_CaliburnMicro_MVVM.Infrastructure
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(AppBootstrapper));

        protected override void Configure()
        {
            XmlConfigurator.Configure();
            container = new Container(x =>
            {
                x.AddRegistry<CaliburnRegistry>();
                x.AddRegistry<ServiceRegistry>();
                x.AddRegistry<ViewModelRegistry>();


            });

            log.Info("Bootstrapper completed");
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotFocusEvent, new RoutedEventHandler(TextBoxGotFocus));
            base.OnStartup(sender, e);
            Application.DispatcherUnhandledException += OnDispatcherUnhandledExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;
            DisplayRootViewFor<MainViewModel>();
            StartApplicationServices();

        }
        private void StartApplicationServices()
        {
            var services = container.GetAllInstances<IApplicationService>().ToList();
            services.ForEach(x => x.Start());
        }

        private void StopApplicationServices()
        {
            var services = container.GetAllInstances<IApplicationService>();
            services.AsParallel().ForAll(x => x.Stop());
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null) textBox.SelectAll();
        }

        private void OnDispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            log.Error("General exception", e.Exception);
            if (e.Handled) return;
            MessageBox.Show(GetExceptionMessages(e.Exception), "Handle Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            log.Error("General exception (task)", e.Exception);
            if (e.Observed) return;
            Execute.OnUIThread(() => MessageBox.Show(GetExceptionMessages(e.Exception), "Handle Error", MessageBoxButton.OK, MessageBoxImage.Error));
        }
        private void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating) return;
            var exception = e.ExceptionObject as Exception;
            log.Error("General exception (current domain)", exception);
            Execute.OnUIThread(() => MessageBox.Show(GetExceptionMessages(exception), "Handle Error", MessageBoxButton.OK, MessageBoxImage.Error));
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            return string.IsNullOrEmpty(key) ? container.GetInstance(serviceType) : container.GetInstance(serviceType, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetAllInstances(serviceType).Cast<object>();
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(GetExceptionMessages(e.Exception), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
        private string GetExceptionMessages(Exception e)
        {
            if (e == null) return "Unexpected error (no exception found)";
            var sb = new StringBuilder();
            sb.AppendLine(e.Message);
            var current = e.InnerException;
            while (current != null)
            {
                sb.Insert(0, string.Format("{0}{1}", current.Message, Environment.NewLine));
                current = current.InnerException;
            }
            return sb.ToString();
        }
        protected override void OnExit(object sender, EventArgs e)
        {
            log.Debug("Application exit");
            StopApplicationServices();
            base.OnExit(sender, e);
        }
    }
}


