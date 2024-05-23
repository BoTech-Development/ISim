using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using ISim.ViewModels;

namespace ISim
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public Control? Build(object? data)
        {
            var name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Not Found: " + name;
                textBlock.Foreground = Brushes.Red;
                return textBlock; // new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}