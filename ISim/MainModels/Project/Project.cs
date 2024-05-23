
using System.Collections.Generic;

namespace ISim.MainModels.Project
{
    public class Project
    {
        public string Name { get; set; } = string.Empty;
        public string mainSchematicPath { get; set; } = string.Empty; // complete json paths
        public List<string> schematicPaths { get; set; } = new List<string>(); // path index in this list is equals to the List subSchematics in SchematicController.
        public List<Package.Package> usedPackages { get; set; } = new List<Package.Package>();

        public Project(string name, string mainSchematicPath, List<string> schematicPaths, List<Package.Package> usedPackages)
        {
            Name = name;
            this.mainSchematicPath = mainSchematicPath;
            this.schematicPaths = schematicPaths;
            this.usedPackages = usedPackages;
        }
    }
}
