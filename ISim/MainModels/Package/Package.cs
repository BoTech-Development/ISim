using System;
using System.Collections.Generic;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Model;

namespace ISim.MainModels.Package
{
    public class Package
    {
        public string packagePath = string.Empty;//stores the dll path that have to be imported
        public List<ObjectData> ObjectData = new List<ObjectData>();// stores data of the importet classes such as name of the class 
        public string packageName = string.Empty;
        public string Author = string.Empty;

        public Package(string packagePath, List<ObjectData> objectData, string packageName, string author)
        {
            this.packagePath = packagePath;
            ObjectData = objectData;
            this.packageName = packageName;
            Author = author;
        }
    }
}
