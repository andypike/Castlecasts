using System.Reflection;
using AndyPike.Castlecasts.UsingWindsor.Controllers;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AndyPike.Castlecasts.UsingWindsor
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<IController>());
        }
    }
}