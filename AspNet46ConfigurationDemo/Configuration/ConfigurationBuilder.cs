using System.Web;

namespace AspNet46ConfigurationDemo.Configuration
{
    public static class ConfigurationBuilder
    {
        public class NullConfiguration : IConfiguration
        {
            public string Get(string key)
            {
                return null;
            }
        }

        public static IConfiguration Create()
        {
            return new NullConfiguration();
        }

        public static IConfiguration UseWebConfig(this IConfiguration configuration)
        {
            return new WebConfigConfiguration(configuration);
        }

        public static IConfiguration UseTextFileConfig(this IConfiguration configuration)
        {
            var configFilePath = HttpContext.Current.Server.MapPath("~/Config.ini");

            return new TextFileConfiguration(configFilePath, configuration);
        }

        public static IConfiguration UseEnvironmentVariablesConfig(this IConfiguration configuration)
        {
            return new EnvironmentVariablesConfiguration(configuration);
        }
    }
}