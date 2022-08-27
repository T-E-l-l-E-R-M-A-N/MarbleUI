namespace MarbleUI.Controls
{
    public class UIToolBarItem : ContentControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIToolBarItem);

        #endregion

        #region Avalonia Properties

        public static readonly StyledProperty<string> LabelProperty =
            AvaloniaProperty.Register<UIToolBarItem, string>("Label");

        #endregion

        #region Public Properties

        public string Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        #endregion
    }
}