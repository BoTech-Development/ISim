
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Info: This Interface is used to represend an object that can do something in the simulation and show its State.
 *      Duríng the Simulation the user can't do anything with it.
 *Example: LED, Display, Magnet...
 * 
 * 
 */
namespace ISim.SchematicEditor.Simulation
{
    public interface IOComponent : IComponent
    {
        // List<Graphic> SimComponents { get; }
    }
}
