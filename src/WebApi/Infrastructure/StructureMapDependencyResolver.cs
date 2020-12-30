using StructureMap;
using System.Web.Http.Dependencies;

namespace WebApi.Infrastructure
{
    public class StructureMapDependencyResolver : StructureMapScope, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }
    }
}