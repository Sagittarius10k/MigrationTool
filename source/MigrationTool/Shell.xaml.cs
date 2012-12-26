using System.ComponentModel.Composition;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.Prism.Logging;
using MigrationTool.Infrastructure;

namespace MigrationTool
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : IPartImportsSatisfiedNotification, ILoggerFacade
    {
        [Import(AllowRecomposition = false)]
        private CallbackLogger _logger; 

        private string LogFilename
        {
            get 
            {
                var loggingSection = (SingleTagSectionHandler)ConfigurationManager.GetSection("LoggerSection");
                return string.Empty;
            }
        }

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            _logger.Callback = Log;
            _logger.ReplaySavedLogs();
        }

        public void Log(string message, Category category, Priority priority)
        {
            using (var file = new FileStream(LogFilename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                
            }
        }
    }
}
