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
            
            builder
                .Register(c => 
                    new EnvironmentVariablesConfiguration(
                        new WebConfigConfiguration()))
                .As<IConfiguration>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}