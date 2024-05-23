


using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace ISim.SchematicEditor.Model
{
    public class Item
    {
        public string ID { get; private set; } = "-1"; // -1 means, that the ID is not set yet => Class IDProvider sets all IDs
        public string Name { get; private set; } = string.Empty;
        public TextBlock Caption { get; set; } = new TextBlock();
        public int zoom { get; set; } = 0; // Represents the zoom factor
        public bool Visible = true;
        public bool Selected { get; set; } = false;
        public Point position = new Point(); //can be used by Logic Components but it is usless to use it in Wire class 
        public Color  fillColor = Colors.LightGray;
        public Color lineColor = Colors.Black;

        public Item(string ID, string Name, string Caption, Color fillColor, Color lineColor, bool Visible = true, bool Selected = false, Point position = default)
        {
            this.Name = Name;
            this.Caption.Text = Caption;
            this.fillColor = fillColor;
            this.lineColor = lineColor;
            this.Visible = Visible;
            this.Selected = Selected;
            this.position = position;
            this.ID = ID;
        }
        public void Refresh()
        {

        }
        public void OnShow(Canvas surface)
        {
            if (Visible)
            {

                //caption.Name = ID + Name;
                Caption.FontSize = 14 + zoom;// 14 is the default Value                            
                Caption.SetValue(Canvas.LeftProperty, position.X);
                Caption.SetValue(Canvas.TopProperty, position.Y);
                if(!surface.Children.Contains(Caption)) surface.Children.Add(Caption);
                if (Selected)
                {
                    lineColor = Colors.AliceBlue;//schow selected color
                }
            }
        }

    }
}
