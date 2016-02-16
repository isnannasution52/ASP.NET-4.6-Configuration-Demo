using System;

namespace AspNet46ConfigurationDemo.Configuration
{
    public class EnvironmentVariablesConfiguration : IConfiguration
    {
        private readonly IConfiguration _backupConfiguration;

        public EnvironmentVariablesConfiguration(IConfiguration backupConfiguration = null)
        {
            _backupConfiguration = backupConfiguration;
        }

        public string Get(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);
            return value ?? _backupConfiguration?.Get(key);
        }
    }
}