using System.Reflection;
using Castle.MonoRail.Framework;

namespace AndyPike.Castlecasts.Website.Filters
{
    public class PopulatePropertyBagFilter : IFilter
    {
        public bool Perform(ExecuteWhen exec, IEngineContext context, IController controller, IControllerContext controllerContext)
        {
            controllerContext.PropertyBag["version"] = Assembly.GetAssembly(controller.GetType()).GetName().Version.ToString();

            return true;
        }
    }
}