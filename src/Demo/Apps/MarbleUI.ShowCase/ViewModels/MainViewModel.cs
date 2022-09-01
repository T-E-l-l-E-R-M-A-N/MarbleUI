using System.Collections.Generic;
using MarbleUI.Controls.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;

namespace MarbleUI.ShowCase
{
    internal class MainViewModel : BindableBase
    {
        #region Private Fields
        private ActionSheetResult _dlgResult = ActionSheetResult.ResultNone;
        private int _indexTab = 1;
        private bool _sideBarIsVisible;
        private MenuItemViewModel _menuItemVm;

        #endregion

        #region Public Properties

        

        public IActionSheetService ActionSheetService { get; set; }
        public ObservableCollection<SimpleTabViewModel?> SimpleTabViewModelsCollection { get; set; } =
            new();

        public SimpleTabViewModel? SelectedTabViewModel { get; set; }

        public bool TabStripIsVisibleKey { get; set; }

        public bool SideBarIsVisible
        {
            get => _sideBarIsVisible;
            set
            {
                if (SelectedTabViewModel != null)
                {
                    _sideBarIsVisible = value;
                }
                else
                {
                    _sideBarIsVisible = value;
                }
                RaisePropertyChanged(nameof(SideBarIsVisible));
            }
        }

        #endregion

        #region Constructor

        public MainViewModel(IActionSheetService actionSheetService)
        {
            ActionSheetService = actionSheetService;

            SimpleTabViewModelsCollection.CollectionChanged += SimpleTabViewModelsCollectionOnCollectionChanged;

            ShowActionSheetCommand = new DelegateCommand(OnShowSheet, OnCanShowSheet);
            ShowActionBoxCommand = new DelegateCommand(OnShowBox);
            CreateTabsCommand = new DelegateCommand(OnCreateTabs, OnCanCreateTabs);

            CreateTabsCommand.Execute();


            
        }

        private void SimpleTabViewModelsCollectionOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (SimpleTabViewModelsCollection.Count >= 2)
            {
                TabStripIsVisibleKey = true;
            }
            else
            {
                TabStripIsVisibleKey = false;

            }
        }

        #endregion

        #region Commands

        public DelegateCommand ShowActionSheetCommand { get; set; }

        public DelegateCommand ShowActionBoxCommand { get; set; }

        public DelegateCommand CreateTabsCommand { get; set; }
        

        #endregion

        #region Commands Methods

        private void OnShowBox()
        {
            _dlgResult = ActionBoxService.ShowBox(_dlgResult != ActionSheetResult.ResultNone ? _dlgResult.ToString() : "Action Box is shown!", "ActionBox Title", ActionSheetBoxButtons.OKCancel,
                ActionSheetBoxDefaultButtonKey.Button1);
        }

        private bool OnCanShowSheet() => ActionSheetService.SheetShow == false;

        private void OnShowSheet() => ActionSheetService.SheetShow = true;

        private bool OnCanCreateTabs() => SimpleTabViewModelsCollection.Count <= 10;

        private async void OnCreateTabs()
        {
            await Task.Run(() =>
            {
                SimpleTabViewModelsCollection.Add(new SimpleTabViewModel($"TabItem number {_indexTab}", _dlgResult, new DelegateCommand<SimpleTabViewModel>(OnClosingTab, OnCanCloseTab), this));
                SelectedTabViewModel = SimpleTabViewModelsCollection.LastOrDefault();
                _indexTab += 1;
            });
        }

        private bool OnCanCloseTab(SimpleTabViewModel arg) => SimpleTabViewModelsCollection.Count >= 1;

        private void OnClosingTab(SimpleTabViewModel obj)
        {
            SimpleTabViewModelsCollection.Remove(obj);
            SelectedTabViewModel = SimpleTabViewModelsCollection.LastOrDefault();
        }

        #endregion

        #region Private Methods

        private MenuItemViewModel GetMenuItemByHeader(IList<MenuItemViewModel> collection, string header)
        {
            return Task.Run(() =>
            {
                foreach (var menuItemViewModel in collection)
                {
                    if (menuItemViewModel.Header == header)
                    {
                        _menuItemVm = menuItemViewModel;
                    }

                    if (menuItemViewModel.Items != null && menuItemViewModel.Items.Count > 0)
                    {
                        GetMenuItemByHeader(menuItemViewModel.Items, header);
                    }
                }

                return _menuItemVm;
            }).Result;
        }

        #endregion
    }
}