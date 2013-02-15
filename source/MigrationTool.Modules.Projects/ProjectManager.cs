using System.Collections.Generic;
using System.ComponentModel.Composition;
using MigrationTool.Infrastructure.BusinessObjects;
using MigrationTool.Infrastructure.Configuration;

namespace MigrationTool.Modules.Projects
{
    [Export]
    public class ProjectManager
    {
#pragma warning disable 0649
        [Import] private ConfigurationManager _configuration;
#pragma warning restore 0649

        public IEnumerable<Project> Projects
        {
            get { return _configuration.GetProject(); }
        }
    }
}
