using Caliburn.Micro;
using StructureMap;
using System;
using WPF_CaliburnMicro_MVVM.ViewModels;

namespace WPF_CaliburnMicro_MVVM.Services
{
    public class ScreenFactory : IScreenFactory
    {
        private readonly IContainer container;

        public ScreenFactory(IContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }

        public Screen Create(string name)
        {
            try
            {
                return container.GetInstance<ViewModelBase>(name.ToUpper());
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create screen for " + name.ToUpper(), ex);
            }
        }

        public T Create<T>() where T : Screen
        {
            return (T)container.GetInstance(typeof(T));
        }

        Screen IScreenFactory.Create(string name)
        {
            throw new NotImplementedException();
        }
    }
}
