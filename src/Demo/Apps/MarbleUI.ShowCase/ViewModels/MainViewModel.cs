using System.Collections.ObjectModel;
using System.Linq;
using MarbleUI.Controls.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    public class MainViewModel : BindableBase
    {
        #region Private Fields
        private ActionSheetResult _dlgResult = ActionSheetResult.ResultNone;
        private int _indexTab = 1;
        #endregion

        #region Public Properties

        public IActionSheetService ActionSheetService { get; set; }
        public ObservableCollection<SimpleTabViewModel?> SimpleTabViewModelsCollection { get; set; } = 
            new();

        public SimpleTabViewModel? SelectedTabViewModel { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IActionSheetService actionSheetService)
        {
            ActionSheetService = actionSheetService;
            
            ShowActionSheetCommand = new DelegateCommand(OnShowSheet, OnCanShowSheet);
            ShowActionBoxCommand = new DelegateCommand(OnShowBox);
            CreateTabsCommand = new DelegateCommand(OnCreateTabs, OnCanCreateTabs);
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

        private void OnCreateTabs()
        {
            SimpleTabViewModelsCollection.Add(new SimpleTabViewModel($"TabItem number {_indexTab}", _dlgResult));
            SelectedTabViewModel = SimpleTabViewModelsCollection.LastOrDefault();
            _indexTab += 1;
        }

        #endregion
    }
}