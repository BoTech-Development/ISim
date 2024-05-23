using Avalonia.Controls;
using Avalonia.Interactivity;
using ISim.ViewModels;
using System;

namespace ISim.Views.SchematicEditor
{
    public partial class SchematicEditorWindow : Window
    {
        public ViewModelBase ownerView;

        public event EventHandler<RoutedEventArgs> OnReady;

        public SchematicEditorWindow(ViewModelBase dataContext, ViewModelBase ownerView)
        {
            InitializeComponent();
            this.ownerView = ownerView;        
            this.DataContext = dataContext;
            this.Loaded += (sender, e) => {
                if (ownerView is NewProjectViewModel) ((NewProjectViewModel)ownerView).ReadyToOpenSolutionEvent();
            };
        }
        public SchematicEditorWindow() { }
    }
}
