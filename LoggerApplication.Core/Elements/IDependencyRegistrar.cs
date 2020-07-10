using Autofac;

namespace LoggerApplication.Core.Elements
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}
