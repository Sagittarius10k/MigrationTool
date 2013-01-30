using System;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "MigrationTool.log", IsRequired = true)]
        public String Name
        {
            get { return (String) this["name"]; }
            set { this["name"] = value; }
        }
    }
}
