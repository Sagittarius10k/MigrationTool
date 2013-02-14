using System.ComponentModel.Composition;
using MigrationTool.Infrastructure;
using MigrationTool.Infrastructure.Configuration;

namespace MigrationTool.Modules.Projects
{
    public class ProjectManager
    {
#pragma warning disable 0649
        [Import] private ConfigurationManager _configuration;
#pragma warning restore 0649


    }
}
