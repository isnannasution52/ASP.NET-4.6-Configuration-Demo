using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AspNet46ConfigurationDemo.Configuration
{
    /// <summary>
    /// This class is not production ready.
    /// It is only a quick and dirty way of reading config values from a text file
    /// to proof the concept of multiple configuration sources.
    /// </summary>
    public class TextFileConfiguration : IConfiguration
    {
        private readonly IConfiguration _backupConfiguration;
        private readonly IDictionary<string, string> _configValues; 

        public TextFileConfiguration(string filePath, IConfiguration backupConfiguration = null)
        {
            _backupConfiguration = backupConfiguration;
            _configValues = new Dictionary<string, string>();

            var lines = File.ReadAllLines(filePath);

            foreach (var keyValuePair 
                in lines
                    .Select(line => line.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries))
                    .Where(keyValuePair => keyValuePair.Length == 2))
            {
                _configValues.Add(
                    keyValuePair[0].Trim(),
                    keyValuePair[1].Trim());
            }
        }

        public string Get(string key)
        {
            var value = _configValues[key];
            return value ?? _backupConfiguration?.Get(key);
        }
    }
}