using StructureMap;
using WPF_CaliburnMicro_MVVM.ViewModels;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Registries
{
    public class ViewModelRegistry: Registry
    {
        public ViewModelRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                //s.With(new SingletonConvention<ViewModelBase>());
                s.AddAllTypesOf<ViewModelBase>();
            });
        }
    }
}
