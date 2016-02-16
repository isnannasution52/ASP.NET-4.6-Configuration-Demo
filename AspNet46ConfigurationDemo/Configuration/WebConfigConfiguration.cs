using System.Configuration;

namespace AspNet46ConfigurationDemo.Configuration
{
    public class WebConfigConfiguration : IConfiguration
    {
        private readonly IConfiguration _backupConfiguration;

        public WebConfigConfiguration(IConfiguration backupConfiguration = null)
        {
            _backupConfiguration = backupConfiguration;
        }

        public string Get(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value ?? _backupConfiguration?.Get(key);
        }
    }
}