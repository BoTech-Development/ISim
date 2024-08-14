using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    public class TestGraphic : ADrawableComponent
    {
        public TestGraphic(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, fillColor, lineColor, parent, childs, geometricObjects)
        {
            Name = name;
            Caption = caption;
            Zoom = zoom;
            Visible = visible;
            Selected = selected;
            Position = position;
            FillColor = fillColor;
            LineColor = lineColor;
            Parent = parent;
            Childs = childs;
            GeometricObjects = geometricObjects;

        }
    }
}
