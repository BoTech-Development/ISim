using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    public class Graphic : ICloneable
    {
        public Geometry Geometry { get; set; }
        public Pen LineColor { get; set; }
        public Brush FillColor { get; set; }
        public Graphic() { }

        public object Clone()
        {
            Graphic clone = new Graphic()
            {
                Geometry = Geometry.Clone(),
                LineColor = new Pen(new SolidColorBrush(((SolidColorBrush)LineColor.Brush).Color)),
                FillColor = new SolidColorBrush(((SolidColorBrush)FillColor).Color)
            };
            return clone;
        }
    }
}
