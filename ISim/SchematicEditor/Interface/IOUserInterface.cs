using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
/*Info: This Interface is used to represend an object that can do something in the simulation and show its State.
 *      Duríng the Simulation the user can click on it.
 *Example: Button, Sensor
 * 
 * 
 */
namespace ISim.SchematicEditor.Interface
{
    public interface IOUserInterface : IOComponent
    {
        Point ClickField1 { get; set; }
        Point CliskField2 { get; set; }

        public void OnMousePopsitionChange(Point mousePosition) { }
        public void OnMouseClick(Point mousePosition, int button) { } //button: 1=>left, 2=>right, 3=>MouseWheel, 4=>Costum
        public void OnKeyboardClick(char button) { } //button represents all characters oion thew users Keyboard, null = key not found => maybe costum key
    }
}
