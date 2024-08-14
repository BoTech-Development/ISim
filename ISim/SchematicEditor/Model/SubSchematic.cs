
using Avalonia;
using Avalonia.Controls;
using ISim.SchematicEditor.Simulation;
using ISim.SchematicEditor.Standard;
using System.Collections.Generic;




namespace ISim.SchematicEditor.Model
{
    public class SubSchematic
    {
        private Schematic mainSchematic = new Schematic(); // Main Schematic of the Project Note: this schemtic do not have to inherit from the mainSchematic
        private SubSchematic baseSchematic = new SubSchematic(); // represents the subschematic from which this schematic inherits. If this schematic inherits from the mainSchematic of the project, set this attribute to null.
        private List<SubSchematic> childSchematics = new List<SubSchematic>();

        public string Name = string.Empty;

        private List<Wire<bool>> wiresBool = new List<Wire<bool>>();
        private List<Wire<int>> wiresTriState = new List<Wire<int>>();
        private List<Wire<float>> wiresAnalog = new List<Wire<float>>();

        private List<Bus<bool>> busBool = new List<Bus<bool>>();
        private List<Bus<int>> busTriState = new List<Bus<int>>();
        private List<Bus<float>> busAnalog = new List<Bus<float>>();

        private List<IComponent> components = new List<IComponent>();
        private List<IOComponent> IOcomponents = new List<IOComponent>();
        private List<IOUserInterface> IOUserInterface = new List<IOUserInterface>();
        /*Info: Shows all Component when they fit in the given canvas size
         *      
         
        public List<object> getSelectedObjects(Point mousePosition, int range)
        {
            List<object> SelectedObjects = new List<object>();
            foreach (var component in components)
            {
                if (component.item.position.X < mousePosition.X + range && component.item.position.X > mousePosition.X - range && component.item.position.Y < mousePosition.Y + range && component.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(component);
                }
            }
            foreach (var component in IOcomponents)
            {
                if (component.item.position.X < mousePosition.X + range && component.item.position.X > mousePosition.X - range && component.item.position.Y < mousePosition.Y + range && component.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(component);
                }
            }
            foreach (var component in IOUserInterface)
            {
                if (component.item.position.X < mousePosition.X + range && component.item.position.X > mousePosition.X - range && component.item.position.Y < mousePosition.Y + range && component.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(component);
                }
            }
            //foreach wire 
            foreach (var wire in wiresBool)
            {
                if (wire.item.position.X < mousePosition.X + range && wire.item.position.X > mousePosition.X - range && wire.item.position.Y < mousePosition.Y + range && wire.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(wire);
                }
            }
            foreach (var wire in wiresTriState)
            {
                if (wire.item.position.X < mousePosition.X + range && wire.item.position.X > mousePosition.X - range && wire.item.position.Y < mousePosition.Y + range && wire.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(wire);
                }
            }
            foreach (var wire in wiresAnalog)
            {
                if (wire.item.position.X < mousePosition.X + range && wire.item.position.X > mousePosition.X - range && wire.item.position.Y < mousePosition.Y + range && wire.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(wire);
                }
            }
            //foreach bus
            foreach (var bus in busBool)
            {
                if (bus.item.position.X < mousePosition.X + range && bus.item.position.X > mousePosition.X - range && bus.item.position.Y < mousePosition.Y + range && bus.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(bus);
                }
            }
            foreach (var bus in busTriState)
            {
                if (bus.item.position.X < mousePosition.X + range && bus.item.position.X > mousePosition.X - range && bus.item.position.Y < mousePosition.Y + range && bus.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(bus);
                }
            }
            foreach (var bus in busAnalog)
            {
                if (bus.item.position.X < mousePosition.X + range && bus.item.position.X > mousePosition.X - range && bus.item.position.Y < mousePosition.Y + range && bus.item.position.Y > mousePosition.X - range)
                {
                    SelectedObjects.Add(bus);
                }
            }
            return SelectedObjects;
        }
        public List<object> getSelectedObjects(Point lowerRange, Point higherRange)
        {
            List<object> SelectedObjects = new List<object>();
            foreach (var component in components)
            {
                if (component.item.position.X < lowerRange.X && component.item.position.X > higherRange.X && component.item.position.Y < lowerRange.Y && component.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(component);
                }
            }
            foreach (var component in IOcomponents)
            {
                if (component.item.position.X < lowerRange.X && component.item.position.X > higherRange.X && component.item.position.Y < lowerRange.Y && component.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(component);
                }
            }
            foreach (var component in IOUserInterface)
            {
                if (component.item.position.X < lowerRange.X && component.item.position.X > higherRange.X && component.item.position.Y < lowerRange.Y && component.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(component);
                }
            }
            //foreach wire 
            foreach (var wire in wiresBool)
            {
                if (wire.item.position.X < lowerRange.X && wire.item.position.X > higherRange.X && wire.item.position.Y < lowerRange.Y && wire.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(wire);
                }
            }
            foreach (var wire in wiresTriState)
            {
                if (wire.item.position.X < lowerRange.X && wire.item.position.X > higherRange.X && wire.item.position.Y < lowerRange.Y && wire.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(wire);
                }
            }
            foreach (var wire in wiresAnalog)
            {
                if (wire.item.position.X < lowerRange.X && wire.item.position.X > higherRange.X && wire.item.position.Y < lowerRange.Y && wire.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(wire);
                }
            }
            //foreach bus
            foreach (var bus in busBool)
            {
                if (bus.item.position.X < lowerRange.X && bus.item.position.X > higherRange.X && bus.item.position.Y < lowerRange.Y && bus.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(bus);
                }
            }
            foreach (var bus in busTriState)
            {
                if (bus.item.position.X < lowerRange.X && bus.item.position.X > higherRange.X && bus.item.position.Y < lowerRange.Y && bus.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(bus);
                }
            }
            foreach (var bus in busAnalog)
            {
                if (bus.item.position.X < lowerRange.X && bus.item.position.X > higherRange.X && bus.item.position.Y < lowerRange.Y && bus.item.position.Y > higherRange.X)
                {
                    SelectedObjects.Add(bus);
                }
            }
            return SelectedObjects;
        }
        public void ShowAll(Point lowerRange, Point higherRange, Canvas surface)
        {
            foreach (var component in components)
            {
                if (component.item.position.X < higherRange.X && component.item.position.X > lowerRange.X && component.item.position.Y < higherRange.Y && component.item.position.Y > lowerRange.Y)
                    component.OnShow(surface);
            }
            foreach (var component in IOcomponents)
            {
                if (component.item.position.X < higherRange.X && component.item.position.X > lowerRange.X && component.item.position.Y < higherRange.Y && component.item.position.Y > lowerRange.Y)
                    component.OnShow(surface);
            }
            foreach (var component in IOUserInterface)
            {
                if (component.item.position.X < higherRange.X && component.item.position.X > lowerRange.X && component.item.position.Y < higherRange.Y && component.item.position.Y > lowerRange.Y)
                    component.OnShow(surface);
            }
            //foreach wire 
            foreach (var wire in wiresBool)
            {
                if (wire.isInRange(lowerRange, higherRange))
                    wire.OnShow(surface);
            }
            foreach (var wire in wiresTriState)
            {
                if (wire.isInRange(lowerRange, higherRange))
                    wire.OnShow(surface);
            }
            foreach (var wire in wiresAnalog)
            {
                if (wire.isInRange(lowerRange, higherRange))
                    wire.OnShow(surface);
            }
            //foreach bus
            foreach (var bus in busBool)
            {
                if (bus.isInRange(lowerRange, higherRange))
                    bus.OnShow(surface);
            }
            foreach (var bus in busTriState)
            {
                if (bus.isInRange(lowerRange, higherRange))
                    bus.OnShow(surface);
            }
            foreach (var bus in busAnalog)
            {
                if (bus.isInRange(lowerRange, higherRange))
                    bus.OnShow(surface);
            }
        }
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
*/
    }
}
