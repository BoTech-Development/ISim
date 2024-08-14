using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    public class Graphic
    {
        public Geometry Geometry { get; set; }
        public Pen LineColor { get; set; }
        public Brush FillColor { get; set; }
        public Graphic() { }
    }
}
