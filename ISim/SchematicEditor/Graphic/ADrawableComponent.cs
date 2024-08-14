﻿using Avalonia;
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
    public abstract class ADrawableComponent : IVisibleComponent
    {
        public string ID { get; }
        public string Name { get; set; } = "";
        public TextBlock Caption { get; set; } = new TextBlock();
        public int Zoom { get; set; } = 0;
        public bool Visible { get; set; } = false;
        public bool Selected { get; set; } = false;
        public Point Position { get; set; } = new Point();
        public Color FillColor { get; set; } = new Color();
        public Color LineColor { get; set; } = new Color();
        public IVisibleComponent Parent { get; set; } 
        public List<IVisibleComponent> Childs { get; set; }
        public List<Graphic> GeometricObjects { get; set; }

        protected ADrawableComponent(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<Graphic> geometricObjects)
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

        public void Draw(DrawingContext context, Surface surface, Rect controlBounds)
        {
            if (Visible && context != null)
            {
                //foreach(var child in Childs) child.Draw(context);

                //Caption.Margin = new Thickness(Position.X, Position.Y, 0, 0);
                //Caption.Render(context);

                // Set the drawing Color to the Drawing helper... The Color will be not used for the Graphic objects

                GeometryDrawing drawing = new GeometryDrawing
                {
                    Brush = new SolidColorBrush(FillColor),
                    Pen = new Pen(new SolidColorBrush(LineColor),1)
                };
                List<Graphic> graphics = surface.convertGraphicToActualPointGraphic(GeometricObjects);
                //Draw each Geometric Object
                foreach(Graphic graphic in graphics)
                {

                    if(graphic.Geometry.Bounds.TopLeft.X >= 0 && graphic.Geometry.Bounds.TopLeft.Y >= 0 && graphic.Geometry.Bounds.BottomRight.X <= controlBounds.Width && graphic.Geometry.Bounds.BottomRight.Y <= controlBounds.Height) 
                    { 
                        drawing.Brush = graphic.FillColor;
                        drawing.Pen = graphic.LineColor;
                        drawing.Geometry = graphic.Geometry;
                        drawing.Draw(context);
                    }
                }
            }
        }
    }
}
