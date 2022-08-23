using Avalonia.Controls.Primitives;
using Avalonia.Platform;

namespace MarbleUI.Controls
{
    public class Window : Avalonia.Controls.Window
    {
        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            TransparencyLevelHint = WindowTransparencyLevel.Blur;
            
            base.OnApplyTemplate(e);
        }

        #endregion
    }
}