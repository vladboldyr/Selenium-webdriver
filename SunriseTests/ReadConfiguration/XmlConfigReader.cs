using Microsoft.Extensions.Configuration;
using System;
using Mir.AutoTests.TestEngine.Settings;
using Mir.AutoTests.TestEngine.Interfaces;
using Mir.AutoTests.TestEngine.Configuration;

namespace SunriseTests
{
    /// <summary>
    /// This class does read configuration file
    /// </summary>
    public class XmlConfigReader : IConfig
  {
        public IConfiguration AppConfiguration { get; set; }

        public XmlConfigReader()
        {
            var builder = new ConfigurationBuilder()
               .AddXmlFile("config.xml");
            AppConfiguration = builder.Build();
        }
        public BrowserType GetBrowser()
        {
            string browser = AppConfiguration[XmlConfigKeys.Browser];
            return (BrowserType) Enum.Parse(typeof(BrowserType), browser);
        }

        public string GetLogin()
        {
            return AppConfiguration[XmlConfigKeys.Login];
        }

        public string GetPassword()
        {
            return AppConfiguration[XmlConfigKeys.Password];
        }

        public string GetUrl()
        {
            return AppConfiguration[XmlConfigKeys.Url];
        }

        public string GetPathToFileKeysForTests()
        {
          return AppConfiguration[XmlConfigKeys.PathToFileKeysForTests];
        }
  }
}
