using System;
using AndyPike.Castlecasts.UsingWindsor.Controllers;
using AndyPike.Castlecasts.UsingWindsor.Installers;
using AndyPike.Castlecasts.UsingWindsor.Shell;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace AndyPike.Castlecasts.UsingWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1 - Install your components
            IWindsorContainer container = new WindsorContainer()
                .Install(Configuration.FromAppConfig(),
                            new HandlersInstaller(), 
                            new ServicesInstaller(),
                            new ControllersInstaller());

            //Step 2 - Resolve your root component(s) - resolve in a single place
            var shell = container.Resolve<IShell>();
            shell.Start();

            var controllers = container.ResolveAll<IController>();
            Console.WriteLine("Controllers resolved from container: " + controllers.Length);

            //Step 3 - Dispose the container
            container.Dispose();
        }
    }
}
