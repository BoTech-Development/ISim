using Avalonia;
using Avalonia.Controls;
using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Simulation;
using ISim.SchematicEditor.Standard;
using System.Collections.Generic;



namespace ISim.SchematicEditor.Model
{
    public class Schematic
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<IVisibleComponent> Components { get; set; } = new List<IVisibleComponent>();
        // The System have to differentiate between Normal Components which have no Background Logic and Components which can be Simulated.
        public List<ISimulatableComponent> SimulatableComponents { get; set; } = new List<ISimulatableComponent>();
        public List<SubSchematic> subSchematics { get; set; } = new List<SubSchematic>();
        public Schematic() { }
    }
}
