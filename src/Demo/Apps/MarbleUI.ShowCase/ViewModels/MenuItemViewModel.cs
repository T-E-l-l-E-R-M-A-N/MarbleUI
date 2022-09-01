using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MarbleUI.Controls;
using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    internal class MenuItemViewModel : BindableBase
    {
        public DelegateCommand Command { get; set; } 
        public string Header { get; set; }
        public IList<MenuItemViewModel> Items { get; set; }

        public bool IsCheckable { get; set; }

        public bool IsChecked { get; set; }

        public bool IsRadioButtonMode { get; set; }
        public string Group { get; set; }

        public MenuItemViewModel()
        {
        }

        
    }
}
