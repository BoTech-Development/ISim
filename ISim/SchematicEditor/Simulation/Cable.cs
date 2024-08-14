using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.SchematicEditor.Simulation
{
    internal class Cable : ADrawableComponent, IOComponent
    {
        public List<Pin<bool>> pinsBool { get; set; }
        public List<Pin<int>> pinsTriState { get; set; }
        public List<Pin<float>> pinsAnalog { get; set; }
        public ObjectData objectData { get; set; }
        public Cable(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<Graphic.Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, fillColor, lineColor, parent, childs, geometricObjects)
        {
        }


    }
}
