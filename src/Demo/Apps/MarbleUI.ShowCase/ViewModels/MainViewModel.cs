using MarbleUI.Controls.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    public class MainViewModel : BindableBase
    {
        private ActionSheetResult _dlgResult = ActionSheetResult.ResultNone;
        public IActionSheetService ActionSheetService { get; set; }
        
        public DelegateCommand ShowActionSheetCommand { get; set; }
        
        public DelegateCommand ShowActionBoxCommand { get; set; }
            

        public MainViewModel(IActionSheetService actionSheetService)
        {
            ActionSheetService = actionSheetService;
            
            ShowActionSheetCommand = new DelegateCommand(OnShowSheet, OnCanShowSheet);
            ShowActionBoxCommand = new DelegateCommand(OnShowBox);
        }

        private void OnShowBox()
        {
            _dlgResult = ActionBoxService.ShowBox(_dlgResult != ActionSheetResult.ResultNone ? _dlgResult.ToString() : "Action Box is shown!", "ActionBox Title", ActionSheetBoxButtons.OKCancel,
                ActionSheetBoxDefaultButtonKey.Button1);
        }

        private bool OnCanShowSheet() => ActionSheetService.SheetShow == false;

        private void OnShowSheet() => ActionSheetService.SheetShow = true;
    }
}