using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.LogicalTree;

namespace MarbleUI.Controls
{
    public abstract class SplitViewBase : ViewBase, ISplitView
    {
        #region Private Fields

        private double _oldGridLength;

        #endregion
        
        #region Avalonia Properties

        public static readonly StyledProperty<double> SplitPaneLengthProperty =
            AvaloniaProperty.Register<SplitViewBase, double>("SplitPaneLength");

        public static readonly StyledProperty<bool> SplitPaneIsVisibleProperty =
            AvaloniaProperty.Register<SplitViewBase, bool>("SplitPaneIsVisible");

        public static readonly StyledProperty<Alignment> PaneAlignmentProperty =
            AvaloniaProperty.Register<SplitViewBase, Alignment>("PaneAlignment");
        
        public static readonly StyledProperty<object> SplitPaneContentProperty =
            AvaloniaProperty.Register<SplitViewBase, object>("SplitPaneContent");

        #endregion
        
        #region Public Properties

        public double SplitPaneLength
        {
            get => SplitPaneIsVisible ? _oldGridLength : 0;
            set
            {
                if (value > 90 || value < this.GetLogicalParent<Window>().Bounds.Width / 2)
                {
                    _oldGridLength = value;
                    SetValue(SplitPaneLengthProperty, _oldGridLength);
                }
            }
        }

        public bool SplitPaneIsVisible
        {
            get => GetValue(SplitPaneIsVisibleProperty);
            set
            {
                SetValue(SplitPaneIsVisibleProperty, value);
            }
        }

        public Alignment PaneAlignment
        {
            get => GetValue(PaneAlignmentProperty);
            set => SetValue(PaneAlignmentProperty, value);
        }

        public object SplitPaneContent
        {
            get => GetValue(SplitPaneContentProperty);
            set => SetValue(SplitPaneContentProperty, value);
        }
        #endregion
        
        #region Protected Methods

        #endregion
    }
}