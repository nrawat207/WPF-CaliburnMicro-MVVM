using WPF_CaliburnMicro_MVVM.ViewModels;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        T Create<T>();
        T Create<T>(string key) where T : ViewModelBase;
    }
}
