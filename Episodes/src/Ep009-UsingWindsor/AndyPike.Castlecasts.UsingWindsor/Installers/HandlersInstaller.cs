using AndyPike.Castlecasts.UsingWindsor.Handlers;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AndyPike.Castlecasts.UsingWindsor.Installers
{
    public class HandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<IPaymentHandler>().ImplementedBy<PayPalHandler>());
        }
    }
}