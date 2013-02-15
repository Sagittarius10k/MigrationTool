namespace MigrationTool.Infrastructure.BusinessObjects
{
    public class Project
    {
        public string Name { get; set; }
        public string StorageUrl { get; set; }
        public bool Compressed { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
