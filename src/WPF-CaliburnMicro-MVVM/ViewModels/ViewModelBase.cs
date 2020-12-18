using Caliburn.Micro;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_CaliburnMicro_MVVM.ViewModels
{
    public abstract class ViewModelBase : Screen, IDisposable
    {
        private bool disposed;

        [SetterProperty]
        public IEventAggregator EventAggregator { get; set; }

        protected override void OnViewLoaded(object view)
        {
            OnLoadedCore();
        }

        public string Title { get; set; }
        public string User { get; set; }

        protected abstract void OnLoadedCore();

        public void SubscribeToMessages()
        {
            EventAggregator.Subscribe(this);
        }
        public void Focus()
        {
            var window = GetView() as Window;
            if (window != null) window.Activate();
        }
        internal string GetProcessException(Exception exception)
        {
            var ex = exception;
            var message = string.Empty;
            Busy = false;
            ExceptionExists = true;
            while (ex != null)
            {
                message += ex.Message + "\n";
                ex = ex.InnerException;
            }
            ViewModelMessage = message;
            return message;
        }

        public string ViewModelMessage { get; set; }

        public bool ExceptionExists { get; set; }

        public bool Busy { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                if (EventAggregator != null)
                {
                    EventAggregator.Unsubscribe(this);
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
