using Caliburn.Micro;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_CaliburnMicro_MVVM.Infrastructure.Factories;
using WPF_CaliburnMicro_MVVM.Services;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Registries
{
    public class CaliburnRegistry:Registry
    {
        public CaliburnRegistry()
        {
            For<IEventAggregator>().Singleton().Use<EventAggregator>();
            For<IWindowManager>().Singleton().Use<WindowManager>();
            For<IViewModelFactory>().Singleton().Use<ViewModelFactory>();
            For<IApplicationService>().Singleton().Use<ModalDialogService>();
        }
    }
}
