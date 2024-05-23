using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels
{
    public class TestWindowViewModel : ViewModelBase
    {
        private string _status = "Binding OK";
        public string Status
        {
            get => _status;
            set => this.RaiseAndSetIfChanged(ref _status, value);
        }

    }
}
