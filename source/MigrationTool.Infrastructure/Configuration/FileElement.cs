using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
