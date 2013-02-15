using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using MigrationTool.Infrastructure.BusinessObjects;

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

                loggerSection.FileElement.Name = loggerSection.FileElement.Name;
            }
            if (projectsSection == null)
            {
                projectsSection = new ProjectsSection();
                _configuration.Sections.Add(ProjectsSection, projectsSection);

                projectsSection.DefaultFolder.Path = projectsSection.DefaultFolder.Path;
            }

            _configuration.Save(ConfigurationSaveMode.Modified);
        }

        public String LogFileName
        {
            get { return ((LoggerSection) _configuration.Sections[LoggerSection]).FileElement.Name; }
        }

        public IEnumerable<Project> GetProject()
        {
            var projects = new List<Project>();
            var projectsSection = _configuration.Sections[ProjectsSection] as ProjectsSection;

            if (projectsSection == null)
                return projects;

            projects.AddRange(from ProjectElement projectElement in projectsSection.Projects
                              select new Project
                                  {
                                      Name = projectElement.Name,
                                      Compressed = projectElement.Compressed,
                                      StorageUrl = projectElement.StorageUrl
                                  });
            return projects;
        }
    }
}
