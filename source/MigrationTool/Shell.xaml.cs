using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
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
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "MEF injected values")]
        [Import] private CallbackLogger _logger;

#pragma warning disable 0649
        [Import]
        //[SuppressMessage("Microsoft.Performance", "CA1823")]
        private ConfigurationManager _configuration;
#pragma warning restore 0649

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
