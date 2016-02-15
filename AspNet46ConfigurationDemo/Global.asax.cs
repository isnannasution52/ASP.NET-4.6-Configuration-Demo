using System.Web.Mvc;
using System.Web.Routing;

namespace AspNet46ConfigurationDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Setup IoC container
            DependencyConfig.Setup();
        }
    }
}
