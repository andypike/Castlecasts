using AndyPike.Castlecasts.UsingWindsor.Services;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AndyPike.Castlecasts.UsingWindsor.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<ILoggingService>().ImplementedBy<ConsoleLoggingService>())
                .Register(Component.For<INotificationService>().ImplementedBy<EmailNotificationService>());
        }
    }
}