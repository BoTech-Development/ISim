
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Enum;
using ISim.SchematicEditor.Model;
using System.Collections.Generic;



namespace ISim.SchematicEditor.Class
{
    public class Pin<T>
    {
        public T Value { get; set; }
        public SignalModesPins Mode = 0; // 0=not defined, 1=bool(T=bool)OUTPUT, 2=tri-State(T=int)OUTPUT, 3=analog(T=float)OUTPUT, 4=UserDefined, 5=bool(T=bool)INPUT, 6=tri-State(T=int)INPUT, 7=analog(T=float)INPUT, 8=UserDefinedINPUT
        public List<Wire<T>> connectedWires = new List<Wire<T>>();

        //View:
        public Item item = null;
        
        public Pin(T defaultValue,SignalModesPins Mode,Point position, Color defaultColor)
        {
            this.Value = defaultValue;
            this.Mode = Mode;   
            this.item = new Item(IDProvider.getIDProvider().getNewIDForPin(), "Wire", "Wire", defaultColor, Colors.LightGray, true, false,position);
            
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
