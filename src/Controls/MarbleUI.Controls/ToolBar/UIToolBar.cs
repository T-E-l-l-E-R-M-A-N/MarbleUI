namespace MarbleUI.Controls
{
    public class UIToolBar : ContentControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIToolBar);

        #endregion

        #region Avalonia Properties

        public static readonly StyledProperty<bool> IsToolBarVisibleProperty = 
            AvaloniaProperty.Register<UIToolBar, bool>("IsToolBarVisible");

        public static readonly StyledProperty<UIToolBarMode> ToolBarModeProperty =
            AvaloniaProperty.Register<UIToolBar, UIToolBarMode>("ToolBarMode");

        #endregion

        #region Public Properties

        public bool IsToolBarVisible
        {
            get => GetValue(IsToolBarVisibleProperty);
            set => SetValue(IsToolBarVisibleProperty, value);
        }

        public UIToolBarMode ToolBarMode
        {
            get => GetValue(ToolBarModeProperty);
            set => SetValue(ToolBarModeProperty, value);
        }

        #endregion
    }
}