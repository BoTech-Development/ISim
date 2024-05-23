using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Model.ObjectData
{
    public class Cathegory
    {
        public List<string> tags { get; set; } = new List<string>();
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

        public Cathegory(string name, string description, List<string> tags)
        {
            this.name = name;
            this.description = description;
            this.tags = tags;
        }
    }
}
