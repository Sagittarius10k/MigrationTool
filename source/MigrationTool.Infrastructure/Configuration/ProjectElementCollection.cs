using System;
using System.Configuration;

namespace MigrationTool.Infrastructure.Configuration
{
    [ConfigurationCollection(typeof (ProjectElement), AddItemName = "project",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ProjectElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProjectElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((ProjectElement)element).Name;
        }
    }
}
