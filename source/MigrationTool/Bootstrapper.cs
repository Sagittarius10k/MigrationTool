using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using MigrationTool.Modules.Editor;
using MigrationTool.Modules.Import;
using MigrationTool.Modules.Projects;

namespace MigrationTool
{
    class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return new Shell();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(EditorModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ImportModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ProjectsModule).Assembly));
        }
    }
}
