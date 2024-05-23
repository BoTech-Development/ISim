using Avalonia.Controls;
using ISim.SchematicEditor.Class;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Model.ObjectData;
using System.Collections.Generic;



/*Info: This Interface is used to represend an object that can do something in the simulation
 *Example: IC, Transistor....
 * 
 * 
 */
namespace ISim.SchematicEditor.Interface
{
    public interface Component
    {
        /*If your component do bot have bool, Tris-State or Analog-Inputs/Outputs please set these Propertys to null.*/

        public List<Pin<bool>> pinsBool {get; set; }
        public List<Pin<int>> pinsTriState { get; set; }
        public List<Pin<float>> pinsAnalog { get; set; }
        public ObjectData objectData { get; set; }//Stores the data for the Browser
        //public List<Pin<T>> pinsCostum { get; set; } // Please decide in each case if you want to support costum pins

        public Item item { get; set; }

        public void OnDelet() { }
        public void OnInputChange() { }
        public void OnShow(Canvas surface) { }
        public void Refresh() { }
        
    }
}
