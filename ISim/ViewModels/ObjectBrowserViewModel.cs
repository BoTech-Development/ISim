using Avalonia.Media;
using Avalonia;
using DynamicData;
using ISim.ViewModels.ObjectBrowser;
using ISim.ViewModels.SchematicEditor;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ISim.SchematicEditor.Graphic;
using Avalonia.Controls;

namespace ISim.ViewModels
{
    public class ObjectBrowserViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewNode> TreeViewNodes { get; }

        private TreeViewNode _selectedTreeViewNode;
        public TreeViewNode SelectedTreeViewNode 
        {
            get => _selectedTreeViewNode;
            set => this.RaiseAndSetIfChanged(ref _selectedTreeViewNode, value);
        }

        public ReactiveCommand<Unit,Unit> OkayCommand { get; set; }

        public SchematicEditorWindowViewModel viewModel { get; set; }
        public ObjectBrowserViewModel() { }



        public ObjectBrowserViewModel(SchematicEditorWindowViewModel viewModel)
        {
            List<Graphic> graphics = new List<Graphic>();
            graphics.Add(new Graphic() { Geometry = new RectangleGeometry(new Rect(new Point(0, 0), new Point(10, 10))), LineColor = new Pen(new SolidColorBrush(Colors.Red)), FillColor = new SolidColorBrush(Colors.Orange) });
            graphics.Add(new Graphic() { Geometry = new EllipseGeometry() { RadiusX = 10, RadiusY = 10, Center = new Point(5, 5) }, LineColor = new Pen(new SolidColorBrush(Colors.Blue)), FillColor = new SolidColorBrush(Colors.LightBlue) });

            TestGraphic testGraphic = new TestGraphic("name", new TextBlock(), 0, true, false, new Point(0, 0), 0, Colors.Red, Colors.Red, null, new List<IVisibleComponent>(), graphics);



            TreeViewNodes = new ObservableCollection<TreeViewNode>
            {
                new TreeViewNode("74lsxx", "", new ObservableCollection<TreeViewNode>
                {
                    new TreeViewNode("74ls08", "", new ObservableCollection<TreeViewNode>(), testGraphic), new TreeViewNode("74ls14", "", new ObservableCollection<TreeViewNode>(), testGraphic), new TreeViewNode("74ls90", "", new ObservableCollection<TreeViewNode>(), testGraphic)
                }, null)
            };
            this.viewModel = viewModel;
            OkayCommand = ReactiveCommand.Create(() =>
            {
                if(SelectedTreeViewNode != null) 
                { 
                    if (viewModel != null) viewModel.PaintControl.AddNewObject(SelectedTreeViewNode.Component);
                }
            });
        }
    }
}
