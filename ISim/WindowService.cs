using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim
{
    public class WindowService : IWindowService
    {
        private static WindowService instance;
        private WindowService()
        {
        }
        public static WindowService getInstance()
        {
            if (instance == null) { instance = new WindowService(); }
            return instance;
        }
        public void ShowWindow(IWindow viewModel)
        {
            if(viewModel != null)
            {
                var window = Activator.CreateInstance(Type.GetType(viewModel.namespaceToView));
                if (window != null) 
                {
                    ((Window)window).Content = viewModel;
                    ((Window)window).Show(); 
                }
            }

        }
    }
}
