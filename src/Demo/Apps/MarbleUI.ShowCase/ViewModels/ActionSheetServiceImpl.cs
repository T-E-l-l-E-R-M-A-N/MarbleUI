using MarbleUI.Controls.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    public class ActionSheetServiceImpl : BindableBase, IActionSheetService
    {
        public object RefuseCommand => new DelegateCommand(() =>
        {
            SheetShow = false;
        });

        public object AcceptCommand => new DelegateCommand(() =>
        {
            SheetShow = false;
        });
        
        public object AcceptParameter { get; set; }
        
        public object RefuseParameter { get; set; }
        public bool SheetShow { get; set; }
    }
}