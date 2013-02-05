using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace MigrationTool.Modules.Projects
{
    [ModuleExport(typeof(ProjectsModule), InitializationMode = InitializationMode.OnDemand)]
    public class ProjectsModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        [ImportingConstructor]
        public ProjectsModule(IRegionViewRegistry registry)
        {
            _regionViewRegistry = registry;
        }

        public void Initialize()
        {
        }
    }
}
