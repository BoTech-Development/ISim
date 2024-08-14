using DynamicData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.ObjectBrowser
{
    public class ObjectBrowserViewModel : ViewModelBase
    {
        public ObservableCollection<TreeViewNode> TreeViewNodes { get; }
        public ObjectBrowserViewModel() 
        {
            TreeViewNodes = new ObservableCollection<TreeViewNode>
            {
                new TreeViewNode("74lsxx", "", new ObservableCollection<TreeViewNode>
                {
                    new TreeViewNode("74ls08", "", null), new TreeViewNode("74ls14","", null), new TreeViewNode("74ls90", "", null)
                }, null)
            };
        }
    }
}
