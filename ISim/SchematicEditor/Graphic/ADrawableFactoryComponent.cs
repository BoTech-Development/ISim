using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    /*
     * This class is used to create drawable objects. These drawable objects are associated with a specific type. 
     * Classes that inherit from this class must always create the same properties using the factory method. 
     * The classes inherited from this class are used during runtime to allow the user to drag new objects onto the schematic. 
     */
    public abstract class ADrawableFactoryComponent
    {
        public ADrawableComponent GetComponentWithDefaultProp()
        {
            return null;
        }
    }
}
