using System.ComponentModel.Composition;
using MigrationTool.Infrastructure;
using MigrationTool.Infrastructure.Behaviors;

namespace MigrationTool.Modules.Projects.ProjectsList
{
    /// <summary>
    /// Interaction logic for ProjectsListView.xaml
    /// </summary>
    [ViewExport(RegionName = RegionNames.ProjectsRegion)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ProjectsListView
    {
        public ProjectsListView()
        {
            InitializeComponent();
        }

        [Import]
        private ProjectsListViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}
