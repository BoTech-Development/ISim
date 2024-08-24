using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Simulation;
using ISim.SchematicEditor.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public TestGraphic()
        {
            Visible = true;
            GeometricObjects = new List<Graphic>();
            GeometricObjects.Add(new Graphic() { Geometry = new RectangleGeometry(new Rect(new Point(0, 0), new Point(10, 10))), LineColor = new Pen(new SolidColorBrush(Colors.Red)), FillColor = new SolidColorBrush(Colors.Orange) });
            GeometricObjects.Add(new Graphic() { Geometry = new LineGeometry(new Point(0, 0), new Point(20, 0)), LineColor = new Pen(new SolidColorBrush(Colors.Red)), FillColor = new SolidColorBrush(Colors.Orange) });
            GeometricObjects.Add(new Graphic() { Geometry = new EllipseGeometry() { RadiusX = 10, RadiusY = 10, Center = new Point(5, 5) }, LineColor = new Pen(new SolidColorBrush(Colors.Blue)), FillColor = new SolidColorBrush(Colors.LightBlue) });
            GeometricObjects.Add(new Graphic() { Geometry = new EllipseGeometry() { RadiusX = 10, RadiusY = 10, Center = new Point(15, 15) }, LineColor = new Pen(new SolidColorBrush(Colors.Blue)), FillColor = new SolidColorBrush(Colors.LightBlue) });
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
        public object Clone()
        {
            TestGraphic clone = new TestGraphic();
            clone.Name = this.Name;
            clone.Caption = this.Caption;
            clone.Zoom = this.Zoom;
            clone.Visible = this.Visible;
            clone.Selected = this.Selected;
            clone.Position = this.Position;
            clone.Orientation = this.Orientation;
            clone.FillColor = this.FillColor;
            clone.LineColor = this.LineColor;
            if (Parent != null)
            {
                clone.Parent = (IVisibleComponent)this.Parent.Clone();
            }
            if (Childs != null)
            {
                foreach (IVisibleComponent child in Childs)
                {
                    clone.Childs.Add((IVisibleComponent)child.Clone());
                }
            }
            if (GeometricObjects != null)
            {
                foreach (Graphic graphic in GeometricObjects)
                {
                    clone.GeometricObjects.Add((Graphic)graphic.Clone());
                }
            }
            return clone;
        }
    }
}
