using Avalonia.Media;
using Avalonia;
using ISim.SchematicEditor.Graphic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Simulation
{
    public interface ISimulatableComponent : IVisibleComponent
    {
        /// <summary>
        ///     This Method have to called after creating an Instance of the Component. The Method Inits for instance the Colors.
        /// </summary>
        /// <returns>
        /// void
        /// </returns
        public void Init();
        /// <summary>
        ///     This Method get called, when the Component has to Simulatre istself. If, for example, an AND gate is to be simulated, the AND connection must be checked in this function.  
        /// </summary>
        /// <returns>
        /// void
        /// </returns
        public void Refresh();
        /// <summary>
        ///     This Method get called, when the Component has to Pre-Draw itself. This Method don't draw directly to the Surface but it has to Prerender the Component so that the Paint Control just has to call the Draw Method.  
        /// </summary>
        /// <returns>
        /// void
        /// </returns
        public void Redraw();
        /// <summary>
        ///     In this Method you have to Reset the Rendered Geometrik Objects to the Stadard Color.
        /// </summary>
        /// <returns>
        /// void
        /// </returns
        public void Reset();
    }
}
