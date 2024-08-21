using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ISim.SchematicEditor.Model;
using ISim.SchematicEditor.Simulation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.SchematicEditor
{
    public class SchematicEditorWindowViewModel : ViewModelBase
    {

      //  public string namespaceToView { get; } = "ISim.Views.SchematicEditor.SchematicEditorWindow";


        ObjectBrowserViewModel _objectBrowser;

        public ObjectBrowserViewModel ObjectBrowser
        {
            get => _objectBrowser;
            private set => this.RaiseAndSetIfChanged(ref _objectBrowser, value);
        }




        private bool _isPaneOpen = true;
        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
        }

        /* Represents the Button width for the Buttons whisch are located in the split view
  */
        private int _menuOpenButtonWidth = 144;
        public int MenuOpenButtonWidth
        {
            get => _menuOpenButtonWidth;
            set => this.RaiseAndSetIfChanged(ref _menuOpenButtonWidth, value);
        }

        private int _menuMargin = 10;
        public int MenuMargin
        {
            get => _menuMargin;
            set => this.RaiseAndSetIfChanged(ref _menuMargin, value);
        }


        private string _statusText = "Binding OK";
        public string StatusText
        {
            get => _statusText;
            set => this.RaiseAndSetIfChanged(ref _statusText, value);
        }
        /// <summary>
        /// Tab Control Template 
        /// </summary>

        private List<TabTemplate> _tabTemplates = new List<TabTemplate>();
        public List<TabTemplate> TabTemplates
        {
            get => _tabTemplates;
            set => this.RaiseAndSetIfChanged(ref _tabTemplates, value);
        }

        private bool _isSimulationEnabled = false;
        public bool IsSimulationEnabled
        {
            get => _isSimulationEnabled;
            set => this.RaiseAndSetIfChanged(ref _isSimulationEnabled, value);
        }

        private bool _isClipToGridForWiresEnabled = false;
        public bool IsClipToGridForWiresEnabled
        {
            get => _isClipToGridForWiresEnabled;
            set => this.RaiseAndSetIfChanged(ref _isClipToGridForWiresEnabled, value);
        }

        public ReactiveCommand<Unit, Unit> PaneMenuCommand { get; set; }
        public ReactiveCommand<int, Unit> ButtonMenuCommand { get; set; }
        public ReactiveCommand<Unit, Unit> HomePositionCommand { get; set; }

        public ReactiveCommand<Unit, Unit> DrawLineCommand { get; set; }

        public ReactiveCommand<Unit, Unit> SimulationCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ResetCommand { get; set; }

        public PaintControl PaintControl { get; set; }
       
        public SimulationController SimulationController { get; set; }
        
        public Schematic Schematic { get; set; }

        private int _zoom = 10;
        public int Zoom
        {
            get => _zoom;
            set => this.RaiseAndSetIfChanged(ref _zoom, value);
        }


        public SchematicEditorWindowViewModel()
        {

            Schematic = new Schematic();
            PaneMenuCommand = ReactiveCommand.Create(() => { IsPaneOpen = !IsPaneOpen; if (IsPaneOpen) { MenuOpenButtonWidth = 144; MenuMargin = 10; } else MenuOpenButtonWidth = 44; MenuMargin = 0; });
           // ButtonMenuCommand = ReactiveCommand.Create<int>(ShowPage);

            HomePositionCommand = ReactiveCommand.Create(() => { PaintControl.HomeScreen(); });
            DrawLineCommand = ReactiveCommand.Create(() => { PaintControl.DrawNewLine(); });
            SimulationCommand = ReactiveCommand.Create(() => 
            {
                if (SimulationController != null)
                {
                    PaintControl.InvalidateVisual();
                    SimulationController.EnableDisableSimulation(!IsSimulationEnabled);
                    IsSimulationEnabled = !IsSimulationEnabled;
                    SimulationController.RunSimulation();
                    //SimulationController.TickSimulation(); 
                    // PaintControl.InvalidateVisual();
                }
            });
        }

        public void SetPaintControl(PaintControl paintControl)
        {
            PaintControl = paintControl;
            InitSimualtion();
        }
        private void InitSimualtion()
        {
            SimulationController = new SimulationController(Schematic, PaintControl);
        }

        public void setObjectBrowser(ObjectBrowserViewModel objectBrowser)
        {
            this.ObjectBrowser = objectBrowser;
        }

        public void OpenSolution(string path, string file)
        {

        }
   
        
    }
}
