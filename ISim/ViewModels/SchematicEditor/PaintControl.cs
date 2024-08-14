using Avalonia;
using Avalonia.Controls;

using Avalonia.Input;

using Avalonia.Media;

using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

/*
 * This Control is used to show all Graphical Components
 * 
 */



namespace ISim.ViewModels.SchematicEditor
{
    public class PaintControl : Control
    {
        [Description("This Property points to the Schematic Editor View")]
        private SchematicEditorWindowViewModel viewModel;
       // [Description("This Property is used to store the Psotion of the upper left Corner of the Control.")]
       // private Point position = new Point(0,0);

        [Description("This Property stores the Zoom Factor")]
        private int Zoom = 10;
        [Description("This Property points to the Surface, which render all Graphic objects.")]
        private Surface surface;
        [Description("This Property is true, when the User move the complete schematic.")]
        private bool movingSurface = false;
        [Description("When this Property is true, the User drag and drop an Visible Component in the Schematic. For instance the User can select an Object from the Object browser and drop it into the Schematic.")]
        private bool dragAndDrop = false;
        [Description("This Property is  true when the User has selected some Object wich he wants to move. Than he can click (hold) with the left Button on the Object to move it. ")]
        private bool movingObjects = false;
        [Description("This Property is true, when the User has to hold the Right mouse Butten, to move the selected Object.")]
        private bool movingObjectsWithHoldingBTN = false;
        [Description("Is true when the user has selected some Onjects with the Select Rectangle.")]
        private bool objectSelected = false;
        [Description("Copy of all Selected Objects. It can be the drag and drop Objects or the selected one. No deep copy, reference only.")]
        private List<ADrawableComponent> selectedObjects = new List<ADrawableComponent>();
        [Description("If this Flag is true the user want to drwa line. ")]
        private bool drawingLines = false;
        [Description("This Flag goes true when the user click the left Mouse Button two times. By the First Click the Line Draw starts and end by the next click.")]
        private bool lineCompleteDrawn = false;
        [Description("This Flag is true when the user click the button to draw a new Line. When the first Part of the Line has been Drawn the flag goes false.")]
        private bool firstLineToDraw = true;
        [Description("Is true when the cursor will automaticly moved to the cross of the Grid.")]
        private bool clipToGrid = true;

        [Description("This Property stores the old Mouse postion.")]
        private Point oldMousPosition;




        private List<ADrawableComponent> drawableComponents = new List<ADrawableComponent>();

        public PaintControl()
        {
            //if(Parent != null)
            //this.DataContext = Parent.DataContext;
            //if (this.DataContext is SchematicEditorWindowViewModel) ((SchematicEditorWindowViewModel)this.DataContext).test(); 
          
            // Setup event handlers
            PointerMoved += PaintControl_PointerMoved;
            PointerPressed += PaintControl_PointerPressed;
            PointerReleased += PaintControl_PointerReleased;
            PointerCaptureLost += PaintControl_PointerCaptureLost;
            SizeChanged += PaintControl_SizeChanged;
          
            //PointerWheelChanged += PaintControl_PointerWheelChanged;
            

            DataContextChanged += PaintControl_DataContextChanged;
           

            KeyDownEvent.AddClassHandler<TopLevel>(PaintControl_KeyDown, handledEventsToo: true);
            KeyUpEvent.AddClassHandler<TopLevel>(PaintControl_KeyUp, handledEventsToo: true);

            List<Graphic> graphics = new List<Graphic>();
            graphics.Add(new Graphic() { Geometry = new RectangleGeometry(new Rect(new Point(10, 10), new Point(40, 40))), LineColor = new Pen(new SolidColorBrush(Colors.Red)), FillColor = new SolidColorBrush(Colors.Orange)});
            graphics.Add(new Graphic() { Geometry = new EllipseGeometry() { RadiusX = 10, RadiusY = 10, Center = new Point(25, 25) }, LineColor = new Pen(new SolidColorBrush(Colors.Blue)), FillColor = new SolidColorBrush(Colors.LightBlue) });
      
            drawableComponents.Add(new TestGraphic("name", new TextBlock(),0,true,false,new Point(0,0), Colors.Red, Colors.Red, null, new List<IVisibleComponent>(), graphics));


            string type = drawableComponents[0].GeometricObjects[0].Geometry.GetType().ToString();

            //Second Test Object
            List<Graphic> graphics2 = new List<Graphic>();
            graphics2.Add(new Graphic() { Geometry = new RectangleGeometry(new Rect(new Point(20, 20), new Point(80, 80))), LineColor = new Pen(new SolidColorBrush(Colors.Green)), FillColor = new SolidColorBrush(Colors.LightGreen) });
            drawableComponents.Add(new TestGraphic("name", new TextBlock(), 0, true, false, new Point(0, 0), Colors.Green, Colors.Green, null, new List<IVisibleComponent>(), graphics2));




            surface = new Surface(this.Bounds);
            surface.Zoom = 10;
        
        }



        [Description("This Method is an Event. It will be called when Avalonia has set the new pointer of the SchematicEditorViewModel to the DataContext. ")]
        private void PaintControl_DataContextChanged(object? sender, EventArgs e)
        {
            if (DataContext is SchematicEditorWindowViewModel)
            {
                (DataContext as SchematicEditorWindowViewModel).PaintControl = this;
                viewModel = (DataContext as SchematicEditorWindowViewModel);

            }
        }

        [Description("This Method is an Event. It will be called when the user moves the Mouse over the Control. When the User press the left button, the System will move the Objects.")]
        private void PaintControl_PointerMoved(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            movingSurface = point.Properties.IsMiddleButtonPressed;
            //Drag the Surface to the given Position
            if (movingSurface) 
            {
                Point newMousePosition = e.GetPosition(this);
                surface.DragSurface(oldMousPosition,newMousePosition);
                oldMousPosition = newMousePosition;
                InvalidateVisual();
            }
            // Move the objects to thge given mouse Position
            if (movingObjects)
            {
                Point actualPoint = surface.convertMousePositionToSurfacePosition(e.GetPosition(this));
                surface.changePositionTo(selectedObjects, actualPoint);
                InvalidateVisual();
            }

            // Render the current Line which has to be drawn so that the user se where he paint the line
            if (drawingLines && lineCompleteDrawn)
            {
                if (clipToGrid) 
                {
                    Cable currentCable = (Cable)selectedObjects[selectedObjects.Count - 1];
                    LineGeometry geometry = (LineGeometry)currentCable.GeometricObjects[currentCable.GeometricObjects.Count - 1].Geometry;
                    geometry.EndPoint = surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position));
                    InvalidateVisual();
                }
                else 
                { 
                    Cable currentCable = (Cable)selectedObjects[selectedObjects.Count - 1];
                    LineGeometry geometry = (LineGeometry)currentCable.GeometricObjects[currentCable.GeometricObjects.Count - 1].Geometry;
                    geometry.EndPoint = surface.convertMousePositionToSurfacePosition(point.Position);
                    InvalidateVisual();
                }
            }
        }

        public void PaintControl_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {

            PointerPoint point = e.GetCurrentPoint(this);
            movingSurface = point.Properties.IsMiddleButtonPressed;

            // Abort the moving Objects scene when left button is Pressed
            if (movingObjects && point.Properties.IsLeftButtonPressed)
            {
                //Copy the new Objects to the list.
                foreach (ADrawableComponent component in selectedObjects)
                {
                    drawableComponents.Add(component);
                }
                selectedObjects = new List<ADrawableComponent>();
                movingObjects = false;
                InvalidateVisual();
            }

            //When the User wants to Draw a line and click the Left Button ones:
            //Whether the current line is placed on the Surface or a new line will be started.
            //Double Clicking the left mouse Button cause the System to abort the line Drawing Process.
            if (drawingLines && point.Properties.IsLeftButtonPressed)
            {
                if (lineCompleteDrawn)
                {
                    Cable currentCable = (Cable)selectedObjects[selectedObjects.Count - 1];
                    LineGeometry geometry = (LineGeometry)currentCable.GeometricObjects[currentCable.GeometricObjects.Count - 1].Geometry; 
                    geometry.EndPoint = surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position));

                    currentCable.GeometricObjects.Add(new Graphic
                    {
                        Geometry = new LineGeometry(surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position)), surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position))),
                        LineColor = new Pen(new SolidColorBrush(Colors.Red)),
                        FillColor = new SolidColorBrush(Colors.Orange)
                    });
                    lineCompleteDrawn = true;
                    InvalidateVisual();
                }
                else
                {
                    // When the first line has to be drawn the system have to create a new instance of complete list and objects 
                    // Otherwise when all Objects are already created the system have only to add a new line.
                    //if (firstLineToDraw)
                    
                    // Add a new Line with dynamic endpooint. => the Endpoint refers to the Mouse Position.
                    List<Graphic> lineGraphics = new List<Graphic>(); // This List stores all sub Lines
                    if (clipToGrid)
                    {
                        lineGraphics.Add(new Graphic
                        {
                            Geometry = new LineGeometry(surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position)), surface.convertMousePositionToSurfacePosition(surface.ClipPointToGrid(point.Position))),
                            LineColor = new Pen(new SolidColorBrush(Colors.Red)),
                            FillColor = new SolidColorBrush(Colors.Orange)
                        });
                    }
                    else
                    {
                        lineGraphics.Add(new Graphic
                        {
                            Geometry = new LineGeometry(surface.convertMousePositionToSurfacePosition(point.Position), surface.convertMousePositionToSurfacePosition(point.Position)),
                            LineColor = new Pen(new SolidColorBrush(Colors.Red)),
                            FillColor = new SolidColorBrush(Colors.Orange)
                        });
                    }
                    Cable cable = new Cable("Cable", new TextBlock { Text = "Cable" }, 0, true, false, new Point(0, 0), Colors.Green, Colors.Green, null, new List<IVisibleComponent>(), lineGraphics);
                    selectedObjects.Add(cable);
                    lineCompleteDrawn = true;
                    firstLineToDraw = false;
                    InvalidateVisual();
                }
            }

            // Gets Called when the pointer is clicked twice:
            if(drawingLines && e.ClickCount == 2)
            {
                // Copying the new Line to the main List of objects
                foreach (ADrawableComponent component in selectedObjects)
                {
                    drawableComponents.Add(component);
                }
                selectedObjects = new List<ADrawableComponent>();
                drawingLines = false;
                lineCompleteDrawn = false;
                firstLineToDraw = true;
                InvalidateVisual();
            }

        }
      
        
        private void PaintControl_PointerReleased(object? sender, Avalonia.Input.PointerReleasedEventArgs e)
        {
        }

        public void PaintControl_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            Zoom = Zoom + (int)e.Delta.Y;
            if (Zoom <= 3) Zoom = 3;
            if (Zoom >= 128) Zoom = 128;
            viewModel.Zoom = Zoom;
            surface.Zoom = Zoom;
            InvalidateVisual();
        }


        private void PaintControl_PointerCaptureLost(object? sender, PointerCaptureLostEventArgs e)
        {
        }

        private void PaintControl_SizeChanged(object? sender, SizeChangedEventArgs e)
        {
           
        }

        private void PaintControl_KeyDown(object? sender, KeyEventArgs e)
        {
           
        }

        private void PaintControl_KeyUp(object? sender, KeyEventArgs e)
        {
           
        }

        public void HomeScreen()
        {
            surface.Reset();
            InvalidateVisual();
        }
        public void AddNewObject(ADrawableComponent componentToAdd)
        {
            objectSelected = false;
            movingObjects = true;
            movingSurface = false;
            dragAndDrop = false;
            movingObjectsWithHoldingBTN = false;
            drawingLines = false;
            lineCompleteDrawn = false;
            selectedObjects = new List<ADrawableComponent> { componentToAdd };
        }
        public void DrawNewLine()
        {
            objectSelected = false;
            movingObjects = true;
            movingSurface = false;
            dragAndDrop = false;
            movingObjectsWithHoldingBTN = false;
            drawingLines = true;
            lineCompleteDrawn = false;
            selectedObjects = new List<ADrawableComponent> ();
        }

        /// <summary>
        /// Render the saved graphic, and marquee when needed
        /// </summary>
        /// <param name="context"></param>
        public override void Render(DrawingContext context)
        {
            
            context.DrawRectangle(new Pen(new SolidColorBrush(Color.FromRgb(128, 128, 128)), 2), new Rect(new Point(Bounds.Left, Bounds.Top), new Point(Bounds.Right, Bounds.Bottom)));
            DrawHVLines(context);
            foreach (ADrawableComponent component in drawableComponents)
            {
                component.Draw(context, surface, this.Bounds);
            }

            foreach (ADrawableComponent component in selectedObjects)
            {
                component.Draw(context, surface, this.Bounds);
            }
        }
        private void DrawHVLines(DrawingContext context)
        {
            if (Parent != null) 
            { 
                Grid grid = this.GetControl<Grid>("PaintControlGrid");
               // position = grid.Bounds.Position;
            }   
            for (int i = 0; i < ((int)this.Bounds.Height / Zoom) * Zoom; i = i + Zoom)
            {
                context.DrawLine(new Pen(new SolidColorBrush(Colors.Gray), 1), new Point(0, i), new Point(Bounds.Right, i));
             
            }
            for (int i = 0; i < ((int)this.Bounds.Width / Zoom) * Zoom; i = i + Zoom)
            {
                context.DrawLine(new Pen(new SolidColorBrush(Colors.Gray), 1), new Point(i, 0), new Point(i, Bounds.Bottom));

            }
        }
    }
}
