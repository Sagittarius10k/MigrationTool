using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;
using MigrationTool.Infrastructure.BusinessObjects;

namespace MigrationTool.Modules.Projects.ProjectsList
{
    [Export(typeof(ProjectsListViewModel))]
    class ProjectsListViewModel : NotificationObject, IPartImportsSatisfiedNotification
    {
#pragma warning disable 0649
        [Import] private ProjectManager _projectManager;
#pragma warning restore 0649

        public ObservableCollection<Project> Projects { get; private set; }

        public void OnImportsSatisfied()
        {
            Projects = new ObservableCollection<Project>(_projectManager.Projects);
            Projects.CollectionChanged += Projects_CollectionChanged;
        }

        void Projects_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
            }
        }
    }
}
