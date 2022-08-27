using Avalonia.Layout;
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
            var dlg = new ActionBox();
            dlg.ActionSheetBoxButtons = buttons;
            dlg.ActionSheetBoxDefaultButtonKey = defaultButton;
            dlg.Content = message;
            dlg.VerticalContentAlignment = VerticalAlignment.Stretch;
            dlg.HorizontalContentAlignment = HorizontalAlignment.Center;
            dlg.Title = caption;
            dlg.ShowInTaskbar = false;
            dlg.Width = 450;
            dlg.Height = 210;
            dlg.Show();
            return dlg.WasClosed ? dlg.ActionSheetBoxResult : ActionSheetResult.ResultNone;
        }
    }
}