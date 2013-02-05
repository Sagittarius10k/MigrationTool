using System;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    public class ProjectElement : ConfigurationElement
    {
        /// <summary>
        /// The name of the project.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get { return (String)this["name"]; }
            set { this["name"] = value; }
        }

        // TODO: Add supports of SVN and Git
        /// <summary>
        /// The storage location in URL form.
        /// </summary>
        [ConfigurationProperty("storageUrl", IsRequired = true)]
        public String StorageUrl
        {
            get { return (String) this["storageUrl"]; }
            set { this["storageUrl"] = value; }
        }

        /// <summary>
        /// Specifies the necessary to compress storage.
        /// </summary>
        [ConfigurationProperty("compressed", DefaultValue = false, IsRequired = true)]
        public Boolean Compressed
        {
            get { return (Boolean)this["compressed"]; }
            set { this["compressed"] = value; }
        }
    }
}
