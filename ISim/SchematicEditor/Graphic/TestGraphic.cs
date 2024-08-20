using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Simulation;
using ISim.SchematicEditor.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    public class TestGraphic : ADrawableComponent, IComponent
    {
        public TestGraphic(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, int orientation, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, orientation, fillColor, lineColor, parent, childs, geometricObjects)
        {
            Name = name;
            Caption = caption;
            Zoom = zoom;
            Visible = visible;
            Selected = selected;
            Position = position;
            Orientation = orientation;
            FillColor = fillColor;
            LineColor = lineColor;
            Parent = parent;
            Childs = childs;
            GeometricObjects = geometricObjects;

        }

        public List<Pin<bool>> PinsBool { get; set; } = new List<Pin<bool>>();
        public List<Pin<int>> PinsTriState { get; set; } = new List<Pin<int>>();
        public List<Pin<float>> PinsAnalog { get; set; } = new List<Pin<float>>();
        public ObjectData objectData { get; set; }

        public void Init()
        {
            
        }

        public void Redraw()
        {
            
        }

        public void Refresh()
        {
            
        }

        public void Reset()
        {
           
        }
    }
}
