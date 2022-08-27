using Avalonia.Input;

namespace MarbleUI.Controls
{
    public class UIView : ViewBase, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIView);

        #endregion
        
        #region Protected Methods

        #endregion
    }
}