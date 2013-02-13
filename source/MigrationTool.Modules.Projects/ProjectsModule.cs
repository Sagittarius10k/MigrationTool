using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace MigrationTool.Modules.Projects
{
    [ModuleExport(typeof(ProjectsModule), InitializationMode = InitializationMode.OnDemand)]
    public class ProjectsModule : IModule
    {
        public void Initialize()
        {
        }
    }
}
