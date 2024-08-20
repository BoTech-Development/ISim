using ISim.SchematicEditor.Model;
using ISim.ViewModels.SchematicEditor;
using System.Timers;
using Avalonia.Media;
using ISim.SchematicEditor.Graphic;
using Avalonia;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Simulation
{
    public class SimulationController
    {
        private Schematic schematic = null;
        private PaintControl paintControl = null;
        private bool simulationEnabled = false;
        private int SimulationIntervall { get; set; } = 1000; //1 Second.
        

        public SimulationController(Schematic schematic, PaintControl paintControl) 
        {
            this.schematic = schematic;
            this.paintControl = paintControl;
        }
        
        public void EnableDisableSimulation(bool enable) 
        {
            simulationEnabled = enable;
            if(!simulationEnabled) Reset();
        }
        private void Reset()
        {
            foreach (ISimulatableComponent component in schematic.SimulatableComponents)
            {
                component.Reset();
            }
            paintControl.InvalidateVisual();
        }
        public async Task RunSimulation()
        {
            while (simulationEnabled)
            {
                TickSimulation();
                await Task.Delay(SimulationIntervall);
            }
        }
        public void TickSimulation()
        {
            foreach(ISimulatableComponent component in schematic.SimulatableComponents)
            {
                component.Refresh();
                component.Redraw();
            }
            paintControl.InvalidateVisual();
        }

    }
}
