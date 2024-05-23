using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.Loader
{
    public class LoadingViewModel : ViewModelBase
    {
        private ObservableCollection<SplitProgressBarDataTemplate> _listSplitProgresses = new ObservableCollection<SplitProgressBarDataTemplate>();
        public ObservableCollection<SplitProgressBarDataTemplate> ListSplitProgresses
        {
            get => _listSplitProgresses;
            set => this.RaiseAndSetIfChanged(ref _listSplitProgresses, value);
        }


        private ObservableCollection<ProgressBarDataTemplate> _listSubProgresses = new ObservableCollection<ProgressBarDataTemplate>();
        public ObservableCollection<ProgressBarDataTemplate> ListSubProgresses
        {
            get => _listSubProgresses;
            set => this.RaiseAndSetIfChanged(ref _listSubProgresses, value);
        }
        private string _headLine = "Bitte warten... (View is initializing)";
        public string HeadLine
        {
            get => _headLine;
            set => this.RaiseAndSetIfChanged(ref _headLine, value);
        }

        public LoadingViewModel(string HeadLine)
        {
            this.HeadLine = HeadLine;
            ListSplitProgresses.Clear();
            ListSubProgresses.Clear();
            ListSplitProgresses.Add(new SplitProgressBarDataTemplate("Waiting", "Init", 100, 0, true, 10));
        }
    }
}
