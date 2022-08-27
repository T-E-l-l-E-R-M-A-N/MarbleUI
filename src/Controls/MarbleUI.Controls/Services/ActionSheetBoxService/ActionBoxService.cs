using System.Threading.Tasks;
using Avalonia.Layout;
using Avalonia.Threading;
using MarbleUI.Controls.Services;

namespace MarbleUI.Controls.Services
{
    public class ActionBoxService
    {
        public static ActionSheetResult ShowBox(string message,
            string caption,
            ActionSheetBoxButtons buttons,
            ActionSheetBoxDefaultButtonKey defaultButton)
        {
            var dlg = new ActionBox
            {
                ActionSheetBoxButtons = buttons,
                ActionSheetBoxDefaultButtonKey = defaultButton,
                Content = message,
                VerticalContentAlignment = VerticalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Title = caption,
                ShowInTaskbar = false,
                Width = 450,
                Height = 210
            };

            dlg.Show();
            
            return dlg.WasClosed ? dlg.ActionSheetBoxResult : ActionSheetResult.ResultNone;
        }
    }
}