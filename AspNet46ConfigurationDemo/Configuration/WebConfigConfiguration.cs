using System.Configuration;

namespace AspNet46ConfigurationDemo.Configuration
{
    public class WebConfigConfiguration : IConfiguration
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}