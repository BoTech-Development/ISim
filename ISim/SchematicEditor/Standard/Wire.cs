using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;





namespace ISim.SchematicEditor.Standard
{
    public class Wire<T> : ADrawableComponent, ISimulatableComponent
    {
        public T Value { get; set; }
        public SignalModes Mode { get; set; } = SignalModes.Userdefined; // 0=not defined, 1=bool(T=bool), 2=tri-State(T=int), 3=analog(T=float), 4=Userdefined
        public Bus<T> busRef = null;

        //View-Related:
        public List<Color> simulationColors = new List<Color>(); // simulationColors[0] => erepresents the default color which will be schown in the Schematic editor. All other colors are for the Simulation.
        public float accuracy = 0.0f;//Use this Value to select the accuracy of the Simulation-Colors

       

        public Wire(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, int orientation, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<SchematicEditor.Graphic.Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, orientation, fillColor, lineColor, parent, childs, geometricObjects)
        {
            
        }

        public void Init()
        {
            switch (Mode)
            {
                case SignalModes.Userdefined:
                    throw new NotImplementedException();
                    break;
                case SignalModes.Bool:
                    // Default
                    LineColor = Colors.Gray;
                    FillColor = Colors.Gray;
                    //simulationColors.Add(Colors.Gray);
                    simulationColors.Add(Colors.Red); // Off
                    simulationColors.Add(Colors.Green); // On
                    break;
                case SignalModes.TRI_State:
                    throw new NotImplementedException();
                    break;
                case SignalModes.Analog:
                    throw new NotImplementedException();
                    break;
            }
        }

        public void Refresh()
        {
            bool value = (bool)Convert.ChangeType(Value, typeof(bool));
            Value = (T)Convert.ChangeType(!value, Value.GetType());
        }
        public void Redraw()
        {
            // This Code change the Color of the Wire whether the Power is on or off.
            Color currentColor = Colors.Gray;

            switch (Mode)
            {
                case SignalModes.Userdefined:
                    throw new NotImplementedException();
                    break;
                case SignalModes.Bool:
                    if (Value is bool)
                    {
                        if ((bool)Convert.ChangeType(Value, typeof(bool)))
                        {
                            //When true or On
                            currentColor = simulationColors[1]; // Change the Color to Green
                        }
                        else
                        {
                            // When false or off
                            currentColor = simulationColors[0]; // Change the Color to Red
                        }
                    }
                    break;
                case SignalModes.TRI_State:
                    throw new NotImplementedException();
                    break;
                case SignalModes.Analog:
                    throw new NotImplementedException();
                    break;
            }

            foreach(Graphic.Graphic graphic in GeometricObjects)
            {
                graphic.FillColor = new SolidColorBrush(currentColor);
                graphic.LineColor = new Pen(new SolidColorBrush(currentColor));
            }
        }
        public void Reset()
        {
            // Set Colors to default:
            foreach (Graphic.Graphic graphic in GeometricObjects)
            {

                graphic.FillColor = new SolidColorBrush(FillColor);
                graphic.LineColor = new Pen(new SolidColorBrush(LineColor));
            }
        }
    }
}
