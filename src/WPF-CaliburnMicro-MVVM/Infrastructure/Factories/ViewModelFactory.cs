using StructureMap;
using System;
using WPF_CaliburnMicro_MVVM.ViewModels;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IContainer _container;

        public ViewModelFactory(IContainer container)
        {
            if (container == null)
                throw new AggregateException("Container");

            _container = container;
        }

        public T Create<T>()
        {
            return _container.GetInstance<T>();
        }

        public T Create<T>(string key) where T : ViewModelBase
        {
            return _container.GetInstance<T>(key);
        }
    }
}
