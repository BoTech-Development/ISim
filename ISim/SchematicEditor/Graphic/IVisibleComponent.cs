using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Graphic
{
    public interface IVisibleComponent : ICountableID
    {
        

        [Description("The Internal Name which won't be showed on the Schematic")]
        public string Name { get; set; } // 

        [Description("This Name will be showed on the Schematic")]
        public TextBlock Caption { get; set; } // This Name will be showed on the Schematic

        [Description("Represents the zoom factor")]
        public int Zoom { get; set; } // Represents the zoom factor

        [Description("When Visible is true then the Component will be showed.")]
        public bool Visible { get; set; } // When Visible is true then it will be showed.

        [Description(" When the user has Selected the Component with his Mouse")]
        public bool Selected { get; set; } // When the user has Selected the Component with his Mouse

        [Description("can be used by Logic Components but it is usless to use it in Wire class ")]
        public Point Position { get; set; } //can be used by Logic Components but it is usless to use it in Wire class 

        [Description("Orientation of the Component. Each Component has to have to rotate. The Orientation will be stored as Degree.")]
        public int Orientation { get; set; }

        [Description("Color Around the Gemoteric Objects")]
        public Color FillColor { get; set; } // Color in the Gemetric Objects

        [Description("Color Around the Gemoteric Objects")]
        public Color LineColor { get; set; }

        [Description("The Parent Visible Component")]
        public IVisibleComponent Parent { get; set; }

        [Description("A list that contains all IVisibleComponents that are one level below this IVisibleComponents.")]
        public List<IVisibleComponent> Childs { get; set; }

        [Description("A list that contains all Geometric Objects that will be drawn with the Draw Method.")]
        public List<Graphic> GeometricObjects { get; set; }

        [Description("Draws the Complete Component and all its Childs and all its Graphical Components. First you have to Draw all Childrens than you can draw the Component.")]
        public void Draw(DrawingContext context, Surface surface, Rect controlBounds);
    }
}
