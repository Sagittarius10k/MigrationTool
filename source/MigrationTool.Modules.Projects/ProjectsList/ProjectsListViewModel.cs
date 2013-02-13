using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;

namespace MigrationTool.Modules.Projects.ProjectsList
{
    [Export(typeof(ProjectsListViewModel))]
    class ProjectsListViewModel : NotificationObject 
    {

    }
}
