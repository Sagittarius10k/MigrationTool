using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class ProjectsSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultFolder")]
        public DefaultFolderElement DefaultFolderElement
        {
            get { return (DefaultFolderElement)this["defaultFolder"]; }
            set { this["defaultFolder"] = value; }
        }
    }
}
