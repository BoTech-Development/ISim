using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.MainModels
{
    internal class Extension
    {
        public int Id = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author {  get; set; } = string.Empty;
        public string pathToDll { get; set; } = string.Empty;

        public Extension(int id, string name, string description, string author, string pathToDll)
        {
            Id = id;
            Name = name;
            Description = description;
            Author = author;
            this.pathToDll = pathToDll;
        }
    }
}
