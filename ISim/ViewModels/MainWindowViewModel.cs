using System;
using System.Reactive;
using System.Reflection.Metadata;
using Avalonia.Controls;
using ISim.ViewModels;
using ISim.ViewModels.Loader;
using ISim.ViewModels.SchematicEditor;
using ISim.Views;

using ReactiveUI;

namespace ISim.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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

        public ReactiveCommand<Unit, Unit> PaneMenuCommand { get; set; }
        public ReactiveCommand<int, Unit> ButtonMenuCommand { get; set; }

        public MainWindowViewModel()
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
                   // new SchematicEditorWindow(new SchematicEditorWindowViewModel(), this).Show();
                    break;
                case 3:
                    
                    break;
                case 4:
                    new SchematicEditorWindow(new SchematicEditorWindowViewModel()).Show();
                    Content = new SettingsViewModel();
                    break;
            }
        }


    }
}
