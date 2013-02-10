using System.Windows;

namespace MigrationTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new MigrationToolBootstrapper();
            bootstrapper.Run();
        }
    }
}
