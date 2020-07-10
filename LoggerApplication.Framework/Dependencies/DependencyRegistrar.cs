using Autofac;
using LoggerApplication.Core.Elements;
using LoggerApplication.Repository;

namespace LoggerApplication.Framework.Dependencies
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public DependencyRegistrar()
        {

        }

        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
