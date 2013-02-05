using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class ProjectsSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultFolder", IsRequired = true)]
        public DefaultFolderElement DefaultFolder
        {
            get { return (DefaultFolderElement)this["defaultFolder"]; }
            set { this["defaultFolder"] = value; }
        }

        [ConfigurationProperty("projects", IsDefaultCollection = false, IsRequired = true)]
        public ProjectElementCollection Projects
        {
            get { return (ProjectElementCollection)this["projects"]; }
            set { this["projects"] = value; }
        }
    }
}
