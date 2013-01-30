using System;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class DefaultFolderElement : ConfigurationElement
    {
        // TODO: Установить значения в "Мои документы\MigrationTool"
        [ConfigurationProperty("path", DefaultValue = ".\\MigrationTool\\", IsRequired = true)]
        public String Path
        {
            get { return (String)this["path"]; }
            set { this["path"] = value; }
        }
    }
}
