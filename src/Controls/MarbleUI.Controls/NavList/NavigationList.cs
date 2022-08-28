namespace MarbleUI.Controls
{
    public class NavigationList : ListBox, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(NavigationList);

        #endregion

        #region Avalonia Properties

        public static readonly StyledProperty<object> TopContentProperty =
            AvaloniaProperty.Register<NavigationList, object>("TopContent");

        #endregion
        
        #region Public Properties

        public object TopContent
        {
            get => GetValue(TopContentProperty);
            set => SetValue(TopContentProperty, value);
        }
        #endregion
    }
}