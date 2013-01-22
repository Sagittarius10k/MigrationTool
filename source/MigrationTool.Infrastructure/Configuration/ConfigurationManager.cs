using System;
using System.ComponentModel.Composition;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    [Export]
    public class ConfigurationManager
    {
        private const String LoggerSection = "loggerSection";
        private readonly System.Configuration.Configuration _configuration;

        public ConfigurationManager()
        {
            //_configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(exePath);
            _configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            if (_configuration.Sections[LoggerSection] == null)
            {
                _configuration.Sections.Add(LoggerSection, new LoggerSection());
                _configuration.Save(ConfigurationSaveMode.Modified);
                System.Configuration.ConfigurationManager.RefreshSection(LoggerSection);
            }
        }

        public String LogFileName
        {
            get { return ((LoggerSection) _configuration.Sections[LoggerSection]).FileElement.Name; }
        }
    }
}
