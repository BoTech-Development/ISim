using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using System.ComponentModel;
/*Info: This Interface is used to represend an object that can do something in the simulation and show its State.
 *      Duríng the Simulation the user can click on it.
 *Example: Button, Sensor
 * 
 * 
 */
namespace ISim.SchematicEditor.Simulation
{
    public interface IOUserInterface : IOComponent
    {

        [Description("This Property descripe in which Field's (rect's) the User can click. When the Subclass for instance represents an ToggleSwitch, the User can click on the Toggle to chanche the Position of the switch.")]
        public List<Rect> fields { get; set; }

        public void OnMouseHover(Point mousePosition) { }
        public void OnMouseClick(Point mousePosition, int button) { } //button: 1=>left, 2=>right, 3=>MouseWheel, 4=>Costum
        public void OnKeyboardClick(char button) { } //button represents all characters oion thew users Keyboard, null = key not found => maybe costum key
    }
}
