using System;
using System.ComponentModel.Composition;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    [Export]
    public class ConfigurationManager
    {
        private const String LoggerSection = "loggerSection";
        private const String ProjectsSection = "projectsSection";
        private readonly System.Configuration.Configuration _configuration;

        public ConfigurationManager()
        {
            //_configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(exePath);
            _configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            var loggerSection = _configuration.Sections[LoggerSection] as LoggerSection;
            var projectsSection = _configuration.Sections[ProjectsSection] as ProjectsSection;

            if (loggerSection == null)
            {
                loggerSection = new LoggerSection();
                _configuration.Sections.Add(LoggerSection, loggerSection);
            }
            if (projectsSection == null)
            {
                projectsSection = new ProjectsSection();
                _configuration.Sections.Add(ProjectsSection, projectsSection);
            }

            loggerSection.FileElement.Name = loggerSection.FileElement.Name;
            projectsSection.DefaultFolderElement.Path = projectsSection.DefaultFolderElement.Path;

            _configuration.Save(ConfigurationSaveMode.Modified);
            //System.Configuration.ConfigurationManager.RefreshSection(LoggerSection);
        }

        public String LogFileName
        {
            get { return ((LoggerSection) _configuration.Sections[LoggerSection]).FileElement.Name; }
        }
    }
}
