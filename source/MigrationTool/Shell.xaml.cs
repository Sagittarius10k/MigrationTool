using System;
using System.ComponentModel.Composition;
using System.IO;
using Microsoft.Practices.Prism.Logging;
using MigrationTool.Infrastructure;
using MigrationTool.Infrastructure.Configuration;

namespace MigrationTool
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : IPartImportsSatisfiedNotification
    {
        [Import] private CallbackLogger _logger;
        [Import] private ConfigurationManager _configuration;
        
        public Shell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the ViewModel
        /// </summary>
        [Import]
        private ShellViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public void OnImportsSatisfied()
        {
            _logger.Callback = Log;
            _logger.ReplaySavedLogs();
        }

        public void Log(string message, Category category, Priority priority)
        {
            using (var file = new FileStream(_configuration.LogFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                var bytes = new byte[message.Length*sizeof (char)];
                Buffer.BlockCopy(message.ToCharArray(), 0, bytes, 0, bytes.Length);
                file.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
