using Avalonia.Controls;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Standard;
using System.Collections.Generic;



/*Info: This Interface is used to represend an object that can do something in the simulation
 *Example: IC, Transistor....
 * 
 * 
 */
namespace ISim.SchematicEditor.Simulation
{
    public interface IComponent : ISimulatableComponent
    {
        /*If your component do bot have bool, Tris-State or Analog-Inputs/Outputs please set these Propertys to null.*/

        public List<Pin<bool>> PinsBool { get; set; } 
        public List<Pin<int>> PinsTriState { get; set; }
        public List<Pin<float>> PinsAnalog { get; set; }
        public ObjectData objectData { get; set; }//Stores the data for the Browser
                                                  //public List<Pin<T>> pinsCostum { get; set; } // Please decide in each case if you want to support costum pins

    }
}
