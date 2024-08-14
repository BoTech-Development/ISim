
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Graphic;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Model.ObjectData;
using ISim.SchematicEditor.Simulation;
using System.Collections.Generic;



namespace ISim.SchematicEditor.Standard
{
    public class Pin<T>: ADrawableComponent
    {
        public T Value { get; set; }
        public SignalModesPins Mode = 0; // 0=not defined, 1=bool(T=bool)OUTPUT, 2=tri-State(T=int)OUTPUT, 3=analog(T=float)OUTPUT, 4=UserDefined, 5=bool(T=bool)INPUT, 6=tri-State(T=int)INPUT, 7=analog(T=float)INPUT, 8=UserDefinedINPUT
        public List<Wire<T>> connectedWires = new List<Wire<T>>();
         
        public Pin(string name, TextBlock caption, int zoom, bool visible, bool selected, Point position, Color fillColor, Color lineColor, IVisibleComponent parent, List<IVisibleComponent> childs, List<SchematicEditor.Graphic.Graphic> geometricObjects) : base(name, caption, zoom, visible, selected, position, fillColor, lineColor, parent, childs, geometricObjects)
        {
        }

        public void OnInputChange()
        {

        }
        public void OnShow(Canvas surface)
        {
        }
        public void Refresh()
        {

        }
    }
}
