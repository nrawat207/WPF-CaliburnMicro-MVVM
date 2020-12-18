using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public class ModalDialogService :IApplicationService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ScreenFactory screenFactory;
        private readonly WindowManager windowManager;

        public ModalDialogService(IEventAggregator eventAggregator, ScreenFactory screenFactory)
        {
            this.eventAggregator = eventAggregator;
            this.screenFactory = screenFactory;
            windowManager = new WindowManager();
        }

        public void Start()
        {
            eventAggregator.Subscribe(this);
        }

        public void Stop()
        {
            eventAggregator.Unsubscribe(this);
        }
    }
}
