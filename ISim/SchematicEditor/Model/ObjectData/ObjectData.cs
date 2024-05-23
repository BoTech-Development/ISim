using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Model.ObjectData
{
    public class ObjectData
    {
        public string Name { get; set; } = String.Empty; // Must set to the name of the derscripted class! The name have to include the Complete Namespace!!!
        public string Description { get; set; } = string.Empty;
        public string ImageSource { get; set; } = null; //Set to null when there you don't want to show a UserDefined Picture
        public Cathegory cathegory { get; set; } = null;
        public int Type { get; set; } = 0;//0=>not setted, 1=>Component, 2=>IOComponent, 3=>IOUserInterface

        public ObjectData(string Name, string Description, Cathegory cathegory, string ImageSource = null) 
        { 
            this.Name = Name;
            this.Description = Description;
            this.cathegory = cathegory;
            this.ImageSource = ImageSource;
        }
    }
}
