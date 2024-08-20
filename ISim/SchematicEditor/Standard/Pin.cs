
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Simulation;
using System;
using System.Collections.Generic;



namespace ISim.SchematicEditor.Standard
{
    public class Pin<T> : ADrawableComponent, ISimulatableComponent
    {
        public T Value { get; set; }
        public SignalModesPins Mode { get; set; } = 0; // 0=not defined, 1=bool(T=bool)OUTPUT, 2=tri-State(T=int)OUTPUT, 3=analog(T=float)OUTPUT, 4=UserDefined, 5=bool(T=bool)INPUT, 6=tri-State(T=int)INPUT, 7=analog(T=float)INPUT, 8=UserDefinedINPUT
        public List<Wire<T>> ConnectedWires { get; set; } = new List<Wire<T>>();
         
        public Pin(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, int orientation, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<SchematicEditor.Graphic.Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, orientation, fillColor, lineColor, parent, childs, geometricObjects)
        {
        }

        public void OnInputChange()
        {

        }



        public void Init()
        {
            GeometricObjects.Clear();

            Point pos = getEndPointOfLineWithAngle(Position, Orientation, 5);
            GeometricObjects.Add(new Graphic.Graphic
            {
                FillColor = new SolidColorBrush(Colors.Gray),
                LineColor = new Pen(new SolidColorBrush(Colors.Gray)),
                Geometry = new LineGeometry(Position, pos) { }
            });
            GeometricObjects.Add(new Graphic.Graphic
            {
                FillColor = new SolidColorBrush(Colors.Transparent),
                LineColor = new Pen(new SolidColorBrush(Colors.Gray)),
                Geometry = new EllipseGeometry()
                {
                    Center = pos,
                    RadiusX = 5,
                    RadiusY = 5

                }
            });
            // draw the second Circle when there is no wire connected to visualisze that the user can Connect a new Wire.
            if (ConnectedWires.Count == 0)
            {
                GeometricObjects.Add(new Graphic.Graphic
                {
                    FillColor = new SolidColorBrush(Colors.Transparent),
                    LineColor = new Pen(new SolidColorBrush(Colors.Gray)),
                    Geometry = new EllipseGeometry()
                    {
                        Center = pos,
                        RadiusX = 8,
                        RadiusY = 8

                    }
                });
            }
            

        }
        private Point getEndPointOfLineWithAngle(Point start, int angle, int length)
        {
            // Convert angle to radians
            double angleRad = angle * (Math.PI / 180);

            // Calculate the end point
            int endX = (int)(start.X + length * Math.Cos(angleRad));
            int endY = (int)(start.Y + length * Math.Sin(angleRad));
            return new Point(endX, endY);
        }
        public bool isMousPointInRange(Point MousePoint)
        {
            Point p = getConnectPoint();
            return p.X - 5 <= MousePoint.X && p.Y - 5 <= MousePoint.Y && p.X + 5 >= MousePoint.X && p.Y + 5 >= MousePoint.Y;
        }
        private Point getConnectPoint()
        {
            return getEndPointOfLineWithAngle(Position, Orientation, 5);
        }
        public void Refresh()
        {

        }
        public void Redraw()
        {
           
        }

        public void Reset()
        {
            
        }
    }
}
