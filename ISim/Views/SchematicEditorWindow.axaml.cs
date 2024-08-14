using Avalonia.Controls;
using Avalonia.Input;
using ISim.ViewModels.SchematicEditor;

namespace ISim.Views
{
    public partial class SchematicEditorWindow : Window
    {
        public SchematicEditorWindow()
        {
            InitializeComponent();
        }
        public SchematicEditorWindow(SchematicEditorWindowViewModel dataContext)
        {
            InitializeComponent();
            this.DataContext = dataContext;
            dataContext.setObjectBrowser(new ViewModels.ObjectBrowserViewModel(dataContext));
            PointerWheelChanged += SchematicEditorWindow_PointerWheelChanged;
            PointerPressed += PaintControl_PointerPressed;
        }
        private void PaintControl_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (DataContext != null)
            {
                if (DataContext is SchematicEditorWindowViewModel viewModel)
                {
                    if (viewModel.PaintControl != null)
                    {
                        viewModel.PaintControl.PaintControl_PointerPressed(sender, e);
                    }
                }
            }
        }
        private void SchematicEditorWindow_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            if (DataContext != null)
            {
                if (DataContext is SchematicEditorWindowViewModel viewModel) 
                {
                    if (viewModel.PaintControl != null) 
                    {
                        viewModel.PaintControl.PaintControl_PointerWheelChanged(sender, e);
                    }
                }
            }
        }
    }
}
