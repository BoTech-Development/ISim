using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Model;
using System;
using System.Collections.Generic;





namespace ISim.SchematicEditor.Class
{
    public class Wire<T>
    {
        public T Value { get; set; }
        public SignalModes Mode = 0; // 0=not defined, 1=bool(T=bool), 2=tri-State(T=int), 3=analog(T=float), 4=Userdefined
        public Bus<T> busRef = null;

        //View:
        public List<Point> positions = new List<Point>();
        public List<Color> simulationColors = new List<Color>(); // simulationColors[0] => erepresents the default color which wioll be schown in the Schematic editor. All other colors arte for the Simulation.
        public float accuracy = 0.0f;//Use this Value to select the accuracy of the Simulation-Colors
        public Item item = null;

        public Wire(T defaultValue, SignalModes Mode, Color defaultColor, List<Color> simulationColors, Bus<T> busRef = null)
        {
            this.Value = defaultValue;
            this.Mode = Mode;
            this.item = new Item(IDProvider.getIDProvider().getNewIDForWire(),"Wire", "Wire", defaultColor, Colors.LightGray,true);
            this.simulationColors = simulationColors;
            this.busRef = busRef;
        }

        public void OnInputChange()
        {

        }
        public void OnShow(Canvas surface)
        {
            Color SimColor = Colors.White;
            //geting the current sim Color which is equals to the state of the Wire
            if(Value.GetType() == typeof(int))
            {
                int value = (int)Convert.ChangeType(Value, typeof(int));
                SimColor = simulationColors[value];
            }else if (Value.GetType() == typeof(bool))
            {
                bool value = (bool)Convert.ChangeType(Value,typeof(bool));
                if (value)
                {
                    SimColor = simulationColors[1];
                }
                else
                {
                    SimColor = simulationColors[2];
                }
            }else if (Value.GetType() == typeof(float))
            {
                float value = (int)Convert.ChangeType(Value, typeof(int)) * accuracy;
                SimColor = simulationColors[(int)value];
            }
            //Drwaing all Lines    
            int i = 0;
            while(i < positions.Count)
            {
                i++;
                Point a = positions[i];
                i++;
                Point b = positions[i];
                Line wireLine = new Line();
                
                wireLine.StartPoint.WithX(a.X);
                wireLine.StartPoint.WithX(a.Y);
                wireLine.Width = b.X;
                wireLine.Height = b.Y;
                wireLine.Stroke = new SolidColorBrush(SimColor);
                surface.Children.Add(wireLine);
            }
        }
        public void Refresh()
        {

        }

        /*Info: Checks if any of the Postions are in this range
         * 
         */
        public bool isInRange(Point lowerRange, Point higherRange)
        {
            foreach(Point point in positions)
            {
                if (point.X < higherRange.X && point.X > lowerRange.X && point.Y < higherRange.Y && point.Y > lowerRange.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
