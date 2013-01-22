using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class LoggerSection : ConfigurationSection
    {
        [ConfigurationProperty("file")]
        public FileElement FileElement
        {
            get { return (FileElement) this["file"]; }
            set { this["file"] = value; }
        }
    }
}
