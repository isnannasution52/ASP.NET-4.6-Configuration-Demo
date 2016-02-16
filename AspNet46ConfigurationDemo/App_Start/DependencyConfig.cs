using System.Web.Mvc;
using AspNet46ConfigurationDemo.Configuration;
using Autofac;
using Autofac.Integration.Mvc;

namespace AspNet46ConfigurationDemo
{
    public class DependencyConfig
    {
        public static void Setup()
        {
            // I used AutoFac to setup the IoC container, but could have been something else like Castle or Ninject, etc.
            var builder = new ContainerBuilder();


            // 1. DECORATOR PATTERN:
            // -------------------------
            // You can use the Decorator pattern to compose a configuration object:

            /*
            var configFilePath = HttpContext.Current.Server.MapPath("~/Config.ini");

            builder
                .Register(c => 
                    new EnvironmentVariablesConfiguration(
                        new TextFileConfiguration(
                            configFilePath,
                            new WebConfigConfiguration())))
                .As<IConfiguration>();

            */

            // 2. FLUENT BUILDER PATTERN:
            // -------------------------
            // Or you can wrap it with a fluent builder pattern and compose it like this:

            var configuration =
                ConfigurationBuilder.Create()
                .UseWebConfig()
                .UseTextFileConfig()
                .UseEnvironmentVariablesConfig();

            builder.RegisterInstance(configuration).As<IConfiguration>();



            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}