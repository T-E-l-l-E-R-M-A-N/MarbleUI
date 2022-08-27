using Avalonia.Input;

namespace MarbleUI.Controls
{
    public class UIView : ViewBase, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIView);

        #endregion
        
        #region Protected Methods

        protected override void SetToolBarMargin(WindowState obj)
        {
            if(_window.Content is UIView && obj is WindowState.FullScreen)
            {
                PART_ToolBarPresenter.Margin = Thickness.Parse("0,0,0,0");
            }
            else
            {
                PART_ToolBarPresenter.Margin = Thickness.Parse("70,0,0,0");
            }
        }


        #endregion
    }
}