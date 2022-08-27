namespace MarbleUI.Controls
{
    public class APControl : ContentControl, IStyleable
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
        
        public static readonly StyledProperty<double> MediaCurrentPositionProperty =
            AvaloniaProperty.Register<APControl, double>("MediaCurrentPosition");
        
        public static readonly StyledProperty<double> MediaLengthProperty =
            AvaloniaProperty.Register<APControl, double>("MediaLength");
        
        public static readonly StyledProperty<double> VolumeMaximumProperty =
            AvaloniaProperty.Register<APControl, double>("VolumeMaximum");
        
        public static readonly StyledProperty<double> VolumeProperty =
            AvaloniaProperty.Register<APControl, double>("Volume");
        
        public static readonly StyledProperty<object> PrevBtnCommandProperty =
            AvaloniaProperty.Register<APControl, object>("PrevBtnCommand");
        
        public static readonly StyledProperty<object> NextBtnCommandProperty =
            AvaloniaProperty.Register<APControl, object>("NextBtnCommand");
        
        public static readonly StyledProperty<object> PlayBtnCommandProperty =
            AvaloniaProperty.Register<APControl, object>("PlayBtnCommand");

        #endregion

        #region Public Properties

        public bool IsSupportsRewinding
        {
            get => GetValue(IsSupportsRewindingProperty);
            set => SetValue(IsSupportsRewindingProperty, value);
        }

        public double MediaLength
        {
            get => GetValue(MediaLengthProperty);
            set => SetValue(MediaLengthProperty, value);
        }

        public double MediaCurrentPosition
        {
            get => GetValue(MediaCurrentPositionProperty);
            set => SetValue(MediaCurrentPositionProperty, value);
        }

        public double VolumeMaximum
        {
            get => GetValue(VolumeMaximumProperty);
            set => SetValue(VolumeMaximumProperty, value);
        }

        public double Volume
        {
            get => GetValue(VolumeProperty);
            set => SetValue(VolumeProperty, value);
        }

        public object PrevBtnCommand
        {
            get => GetValue(PrevBtnCommandProperty);
            set => SetValue(PrevBtnCommandProperty, value);
        }

        public object NextBtnCommand
        {
            get => GetValue(NextBtnCommandProperty);
            set => SetValue(NextBtnCommandProperty, value);
        }

        public object PlayBtnCommand
        {
            get => GetValue(PlayBtnCommandProperty);
            set => SetValue(PlayBtnCommandProperty, value);
        }
        
        #endregion
    }
}