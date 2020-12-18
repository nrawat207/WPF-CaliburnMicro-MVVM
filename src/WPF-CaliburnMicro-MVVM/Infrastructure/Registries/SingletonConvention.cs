using StructureMap;
using StructureMap.Graph;
using StructureMap.Graph.Scanning;
using StructureMap.TypeRules;
using System;
using System.Linq;

namespace WPF_CaliburnMicro_MVVM.Infrastructure.Registries
{
    internal class SingletonConvention<TPluginFamily> : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || !type.CanBeCreated() || !type.AllInterfaces().Contains(typeof(TPluginFamily))) return;

            registry.For(typeof(TPluginFamily)).Singleton().Use(type);
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.AllTypes())
            {
                Process(type, registry);
            }
        }
    }
}
