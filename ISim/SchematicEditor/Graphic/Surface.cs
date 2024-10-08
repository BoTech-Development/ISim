﻿using Avalonia;
using Avalonia.Media;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace ISim.SchematicEditor.Graphic
{
    public class Surface
    {
        public int Zoom {  get; set; }
        private System.Drawing.Point startPoint = new System.Drawing.Point(0,0);
        private System.Drawing.Point endPoint;
        public Rect Bounds;

        public Surface(Rect Bounds) 
        { 
            this.Bounds = Bounds;
        }



        public Point getActualPositionOf(Point surfacePoint)
        {
            //return new Point(surfacePoint.X * (129 - Zoom),surfacePoint.Y * (129 - Zoom));
            return new Point(startPoint.X + (surfacePoint.X * Zoom), startPoint.Y + (surfacePoint.Y * Zoom));
        }


        public void DragSurface(Point oldMousePosition, Point newMousePosition)
        {
            Point actualOldMousePos = convertMousePositionToSurfacePosition(oldMousePosition);
            Point actualNewMousePos = convertMousePositionToSurfacePosition(newMousePosition);

            startPoint.X = startPoint.X + (int)(newMousePosition.X - oldMousePosition.X);
            startPoint.Y = startPoint.Y + (int)(newMousePosition.Y - oldMousePosition.Y);
        }

        public void Reset()
        {
            startPoint = new System.Drawing.Point(0,0);
        }


        [Description("This Method returns the actual Position of the Mouse Pointer by using the zoom factor. This Method do not include the Start Position of the view.")]
        public Point convertMousePositionToSurfacePosition(Point mouseposition)
        {
            return new Point(mouseposition.X / Zoom, mouseposition.Y / Zoom);
        }
        public bool isVisible(Point componentPoint)
        {
            return (startPoint.X <= componentPoint.X && startPoint.Y <= componentPoint.Y && endPoint.X >= componentPoint.X && endPoint.Y >= componentPoint.Y);
        }
        [Description("This Method convert the garphics objects to new graphic objects which can be drawn on the paint Conteo. You need this method to include the zoom in the calculation of the output.")]
        public List<Graphic> convertGraphicToActualPointGraphic(List<Graphic> graphics)
        {
            List<Graphic> result = new List<Graphic>();
            foreach (Graphic graphic in graphics) 
            {
                
                switch (graphic.Geometry.GetType().ToString())
                {
                    case "Avalonia.Media.EllipseGeometry":
                        EllipseGeometry ellipse = graphic.Geometry as EllipseGeometry;
                        EllipseGeometry newEllipse = new EllipseGeometry();
                        if (ellipse != null)
                        {
                            newEllipse.Center = getActualPositionOf(ellipse.Center);
                            newEllipse.RadiusX = ellipse.RadiusX;
                            newEllipse.RadiusY = ellipse.RadiusY;
                            result.Add(new Graphic() { Geometry = newEllipse, FillColor = graphic.FillColor, LineColor = graphic.LineColor});
                        }
                        break;
                    case "Avalonia.Media.LineGeometry":
                        LineGeometry line = graphic.Geometry as LineGeometry;
                        LineGeometry newLine = new LineGeometry();
                        if (line != null)
                        {
                            newLine.StartPoint = getActualPositionOf(line.StartPoint);
                            newLine.EndPoint = getActualPositionOf(line.EndPoint);
                            result.Add(new Graphic() { Geometry = newLine, FillColor = graphic.FillColor, LineColor = graphic.LineColor });
                        }
                        break;
                    case "Avalonia.Media.RectangleGeometry":
                        RectangleGeometry rect = graphic.Geometry as RectangleGeometry;
                        RectangleGeometry newRect = new RectangleGeometry();
                        if (rect != null)
                        {
                            newRect.Rect = new Rect(getActualPositionOf(rect.Rect.TopLeft), getActualPositionOf(rect.Rect.BottomRight));
                            result.Add(new Graphic() { Geometry = newRect, FillColor = graphic.FillColor, LineColor = graphic.LineColor });
                        }
                        break;
                    case "Avalonia.Media.PolylineGeometry":
                        throw new NotImplementedException();
                        break;
                    case "Avalonia.Media.StreamGeometry":
                        throw new NotImplementedException();
                        break;
                }
            }
            return result;
        }
        public List<IVisibleComponent> changeComponentPositionTo(List<IVisibleComponent> components, Point newPos)
        {
            foreach (IVisibleComponent component in components)
            {
                List<Graphic> resultGraphics = new List<Graphic>();
                foreach (Graphic graphic in component.GeometricObjects)
                {
                    switch (graphic.Geometry.GetType().ToString())
                    {
                        case "Avalonia.Media.EllipseGeometry":
                            EllipseGeometry ellipse = graphic.Geometry as EllipseGeometry;
                            EllipseGeometry newEllipse = new EllipseGeometry();
                            if (ellipse != null)
                            {
                                newEllipse.Center = newPos + ellipse.Center;
                                newEllipse.RadiusX = ellipse.RadiusX;
                                newEllipse.RadiusY = ellipse.RadiusY;
                                resultGraphics.Add(new Graphic() { Geometry = newEllipse, FillColor = graphic.FillColor, LineColor = graphic.LineColor });
                            }
                            break;
                        case "Avalonia.Media.LineGeometry":
                            LineGeometry line = graphic.Geometry as LineGeometry;
                            LineGeometry newLine = new LineGeometry();
                            if (line != null)
                            {
                                newLine.StartPoint = newPos + line.StartPoint;
                                newLine.EndPoint = newPos + line.EndPoint;
                                resultGraphics.Add(new Graphic() { Geometry = newLine, FillColor = graphic.FillColor, LineColor = graphic.LineColor });
                            }
                            break;
                        case "Avalonia.Media.RectangleGeometry":
                            RectangleGeometry rect = graphic.Geometry as RectangleGeometry;
                            RectangleGeometry newRect = new RectangleGeometry();
                            if (rect != null)
                            {
                                newRect.Rect = new Rect(newPos + rect.Rect.TopLeft, newPos + rect.Rect.BottomRight);
                                resultGraphics.Add(new Graphic() { Geometry = newRect, FillColor = graphic.FillColor, LineColor = graphic.LineColor });
                            }
                            break;
                        case "Avalonia.Media.PolylineGeometry":
                            throw new NotImplementedException();
                            break;
                        case "Avalonia.Media.StreamGeometry":
                            throw new NotImplementedException();
                            break;

                    }
                }
                component.GeometricObjects = resultGraphics;
            }
            return components;
        }
        public List<IVisibleComponent> GetSelectedComponentsInRange(Rect range, Schematic schematic)
        {
            List<IVisibleComponent> result = new List<IVisibleComponent>();
            foreach (IVisibleComponent component in schematic.Components)
            {
                foreach (Graphic graphic in component.GeometricObjects)
                {
                    if ((range.TopLeft.X < graphic.Geometry.Bounds.TopLeft.X && range.TopLeft.Y < graphic.Geometry.Bounds.TopLeft.Y) && (range.BottomRight.X > graphic.Geometry.Bounds.BottomRight.X && range.BottomRight.Y > graphic.Geometry.Bounds.BottomRight.Y))
                    {
                        result.Add(component);
                        break;
                    }
                }
            }
            foreach(ISimulatableComponent simulatableComponent in schematic.Components)
            {
                foreach (Graphic graphic in simulatableComponent.GeometricObjects)
                {
                    if (graphic.Geometry.Bounds.Contains(range))
                    {
                        result.Add(simulatableComponent);
                        break;
                    }
                }
            }
            return result;
        }
        public Point ClipPointToGrid(Point point)
        {
            int newX;
            int newY;
            // For the X-Coordinate
            if (point.X % Zoom > Zoom / 2)
            {
                // Aufrunden
                newX = (int)(point.X + (Zoom - (point.X % Zoom)));
            }
            else
            {
                // Abrunden
                newX = (int)(point.X - (point.X % Zoom));
            }
            //For the Y-Coordinate
            if (point.Y % Zoom > Zoom / 2)
            {
                // Aufrunden
                newY = (int)(point.Y + (Zoom - (point.Y % Zoom)));
            }
            else
            {
                // Abrunden
                newY = (int)(point.Y - (point.Y % Zoom));
            }
            return new Point(newX, newY);
        }
    }

}
