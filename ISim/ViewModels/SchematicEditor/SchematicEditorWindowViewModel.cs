using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.SchematicEditor
{
    public class SchematicEditorWindowViewModel : ViewModelBase
    {

      //  public string namespaceToView { get; } = "ISim.Views.SchematicEditor.SchematicEditorWindow";


        ViewModelBase content;

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
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


        public SchematicEditorWindowViewModel()
        {
            Content = new HomeViewModel();
            PaneMenuCommand = ReactiveCommand.Create(() => { IsPaneOpen = !IsPaneOpen; if (IsPaneOpen) { MenuOpenButtonWidth = 144; MenuMargin = 10; } else MenuOpenButtonWidth = 44; MenuMargin = 0; });
            ButtonMenuCommand = ReactiveCommand.Create<int>(ShowPage);
        }

        public void ShowPage(int pageID)
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
        }
        
        public void OpenSolution(string path, string file)
        {

        }
    }
}
