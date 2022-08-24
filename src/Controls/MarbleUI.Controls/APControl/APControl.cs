namespace MarbleUI.Controls
{
    public class APControl : TemplatedControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(APControl);

        #endregion
        
        #region Avalonia Properties
        /// <summary>
        /// Shows he ability to change the playing position using slider
        /// </summary>

        public static readonly StyledProperty<bool> IsSupportsRewindingProperty =
            AvaloniaProperty.Register<APControl, bool>("IsSupportsRewinding");
        
        //public static 

        #endregion

        #region Public Properties

        public bool IsSupportsRewinding
        {
            get => GetValue(IsSupportsRewindingProperty);
            set => SetValue(IsSupportsRewindingProperty, value);
        }

        #endregion
    }
}