using Avalonia.Controls;
using ISim.ViewModels;
using ReactiveUI;

namespace ISim.Views
{
    public partial class Loading : Window
    {
        public Loading(ViewModelBase viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        public Loading() { }
    }
}
