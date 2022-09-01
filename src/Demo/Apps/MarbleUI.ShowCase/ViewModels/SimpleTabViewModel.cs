using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    internal class SimpleTabViewModel : BindableBase
    {
        private readonly MainViewModel _mainViewModel;
        private MenuItemViewModel CreateItem(string header, string @group, bool IsChecked = false)
        {
            var item = new MenuItemViewModel()
            {
                Header = header,
                IsCheckable = true,
                IsChecked = IsChecked,
                Command = MenuItemCommand,
                Group = group
            };

            item.PropertyChanged += MenuItemPropertyChanged;
            return item;
        }
        public string Header { get; set; }

        public object? Content { get; set; }

        public ObservableCollection<MenuItemViewModel> MenuCollection { get; set; } =
            new();
        public DelegateCommand<SimpleTabViewModel> CloseCommand { get; set; }
        public DelegateCommand MenuItemCommand { get; set; }

        public SimpleTabViewModel(string header, object? content, DelegateCommand<SimpleTabViewModel> closeCommand, MainViewModel _mainViewModel)
        {
            this._mainViewModel = _mainViewModel;
            Header = header;
            Content = content;
            CloseCommand = closeCommand;

            MenuCollection.Add(new MenuItemViewModel()
            {
                Header = "View",
                Items = new ObservableCollection<MenuItemViewModel>()
                {
                    CreateItem("Light Theme", "view", true),
                    CreateItem("Dark Theme", "view"),
                }
            });
        }

        private void MenuItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MenuItemViewModel.IsChecked))
            {
                var item = (MenuItemViewModel)sender;
                if (item.IsChecked)
                {
                    // проходишься по всем итемам и сбрасываешь у всех Checked в false кроме item'a, который стал Checked
                    UncheckItems(MenuCollection, item.Header, item.Group);
                }
            }
        }

        private void UncheckItems(IList<MenuItemViewModel> menuItemViewModels, string header, string group)
        {
            if (menuItemViewModels != null)
            {
                foreach (var menuItemViewModel in menuItemViewModels)
                {
                    UncheckItems(menuItemViewModel.Items, header, group);

                    if (menuItemViewModel.Group == group)
                    {
                        menuItemViewModel.IsChecked = false;
                    }
                }
            }
        }
    }
}