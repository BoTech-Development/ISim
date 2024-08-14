using Avalonia;
using Avalonia.Controls;
using ISim.SchematicEditor.Simulation;
using ISim.SchematicEditor.Standard;
using System.Collections.Generic;



namespace ISim.SchematicEditor.Model
{
    public class Schematic
    {
        private List<Wire<bool>> wiresBool = new List<Wire<bool>>();
        private List<Wire<int>> wiresTriState = new List<Wire<int>>();
        private List<Wire<float>> wiresAnalog = new List<Wire<float>>();

        private List<Bus<bool>> busBool = new List<Bus<bool>>();
        private List<Bus<int>> busTriState = new List<Bus<int>>();
        private List<Bus<float>> busAnalog = new List<Bus<float>>();

        private List<IComponent> components = new List<IComponent>();
        private List<IOComponent> IOcomponents = new List<IOComponent>();
        private List<IOUserInterface> IOUserInterface = new List<IOUserInterface>();



        /*Info: Schows all Componentws when they fit in the given canvas size*/
        
          //**********************************************-ADD-FUNCTIONS*************************************//
        public void AddWire(Wire<bool> wire)
        {
            if (wire != null)
            {
                //if (wire.GetType().Equals(typeof(Wire<bool>)))
                wiresBool.Add(wire);
            }
        }
        public void AddWire(Wire<int> wire)
        {
            if (wire != null)
            {
                wiresTriState.Add(wire);
            }
        }
        public void AddWire(Wire<float> wire)
        {
            if (wire != null)
            {
                wiresAnalog.Add(wire);
            }
        }
        public void AddBus(Bus<bool> bus)
        {
            if (bus != null)
            {
                //if (wire.GetType().Equals(typeof(Wire<bool>)))
                busBool.Add(bus);
            }
        }
        public void AddBus(Bus<int> bus)
        {
            if (bus != null)
            {
                busTriState.Add(bus);
            }
        }
        public void AddBus(Bus<float> bus)
        {
            if (bus != null)
            {
                busAnalog.Add(bus);
            }
        }
        public void AddComponent(IComponent component)
        {
            if (component != null)
            {
                //if (wire.GetType().Equals(typeof(Wire<bool>)))
                components.Add(component);
            }
        }
        public void AddIOComponent(IOComponent component)
        {
            if (component != null)
            {
                IOcomponents.Add(component);
            }
        }
        public void AddIOUserInterface(IOUserInterface component)
        {
            if (component != null)
            {
                IOUserInterface.Add(component);
            }
        }
    }
    
}
