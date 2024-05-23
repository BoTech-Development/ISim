
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> PreviousPicCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NextPicCommand { get; set; }
        
        public HomeViewModel( )
        {
            PreviousPicCommand = ReactiveCommand.Create(() => {  });
        }


    }
}
