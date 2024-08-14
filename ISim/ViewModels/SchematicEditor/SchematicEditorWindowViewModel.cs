using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
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


        public ReactiveCommand<Unit, Unit> PaneMenuCommand { get; set; }
        public ReactiveCommand<int, Unit> ButtonMenuCommand { get; set; }
        public ReactiveCommand<Unit, Unit> HomePositionCommand { get; set; }

        public ReactiveCommand<Unit, Unit> DrawLineCommand { get; set; }

        public PaintControl PaintControl { get; set; }

        private int _zoom = 10;
        public int Zoom
        {
            get => _zoom;
            set => this.RaiseAndSetIfChanged(ref _zoom, value);
        }






        public SchematicEditorWindowViewModel()
        {
            
            PaneMenuCommand = ReactiveCommand.Create(() => { IsPaneOpen = !IsPaneOpen; if (IsPaneOpen) { MenuOpenButtonWidth = 144; MenuMargin = 10; } else MenuOpenButtonWidth = 44; MenuMargin = 0; });
           // ButtonMenuCommand = ReactiveCommand.Create<int>(ShowPage);

            Canvas myCanvas1 = new Canvas();
            myCanvas1.Background = Brushes.Red;
            myCanvas1.Height = 100;
            myCanvas1.Width = 100;
            Canvas.SetTop(myCanvas1, 0);
            Canvas.SetLeft(myCanvas1, 0);

            Canvas myCanvas2 = new Canvas();
            myCanvas2.Background = Brushes.Green;
            myCanvas2.Height = 100;
            myCanvas2.Width = 100;
            Canvas.SetTop(myCanvas2, 100);
            Canvas.SetLeft(myCanvas2, 100);

            Canvas myCanvas3 = new Canvas();
            myCanvas3.Background = Brushes.Blue;
            myCanvas3.Height = 100;
            myCanvas3.Width = 100;
            Canvas.SetTop(myCanvas3, 50);
            Canvas.SetLeft(myCanvas3, 50);

            // Add child elements to the Canvas' Children collection
            /*Surface = new Canvas();

            Surface.Children.Add(myCanvas1);
            Surface.Children.Add(myCanvas2);
            Surface.Children.Add(myCanvas3);
            */

            HomePositionCommand = ReactiveCommand.Create(() => { PaintControl.HomeScreen(); });
            DrawLineCommand = ReactiveCommand.Create(() => { PaintControl.DrawNewLine(); });
        }


        public void setObjectBrowser(ObjectBrowserViewModel objectBrowser)
        {
            this.ObjectBrowser = objectBrowser;
        }

       /* public void ShowPage(int pageID)
        {
            switch (pageID)
            {
                case 0:
                    Content = new HomeViewModel();
                    break;
                case 1:
                    Content = new NewProjectViewModel();
                    break;
                case 2:
                    Content = new HomeViewModel();
                    break;
                case 3:
                    Content = new HomeViewModel();
                    break;
                case 4:
                    Content = new SettingsViewModel();
                    break;
            }
        }*/
        
        public void OpenSolution(string path, string file)
        {

        }
   
        
    }
}
