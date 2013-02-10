using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using MigrationTool.Infrastructure;
using MigrationTool.Infrastructure.Behaviors;
using MigrationTool.Modules.Editor;
using MigrationTool.Modules.Import;
using MigrationTool.Modules.Projects;

namespace MigrationTool
{
    class MigrationToolBootstrapper : MefBootstrapper
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

            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ShellViewModel).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(CallbackLogger).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(EditorModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ImportModule).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ProjectsModule).Assembly));
        }

        protected override Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = base.ConfigureDefaultRegionBehaviors();
            factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));

            return factory;
        }
    }
}
