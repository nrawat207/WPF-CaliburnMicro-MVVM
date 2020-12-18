using Caliburn.Micro;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public interface IScreenFactory
    {
        Screen Create(string name);
        T Create<T>() where T : Screen;
    }
}
