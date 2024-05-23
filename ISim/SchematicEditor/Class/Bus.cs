

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Model;
using System.Collections.Generic;

namespace ISim.SchematicEditor.Class
{
    public class Bus<T>
    {
        public T Value { get; set; }
        public SignalModes Mode = 0; // 0=not defined, 1=bool(T=bool), 2=tri-State(T=int), 3=analog(T=float), 4=UserDefined

        //View:
        public List<Point> positions = new List<Point>();
      //  public List<Color> simulationColors = new List<Color>();
        public Item item = null;

        public Bus(T defaultValue, SignalModes mode, List<Point> positions, Color defaultColor)
        {
            Value = defaultValue;
            Mode = mode;
            this.positions = positions;
            this.item = new Item(IDProvider.getIDProvider().getNewIDForBus(), "Wire", "Wire", defaultColor, Colors.LightGray,true);
        }

        public void OnInputChange(List<Wire<T>> changedWires)
        {

        }
        public void OnShow(Canvas surface)
        {
        }
        public void Refresh()
        {

        }
        /*Info: Checks if any of the Postions are in this range
         * 
         */
        public bool isInRange(Point lowerRange, Point higherRange)
        {
            foreach (Point point in positions)
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
