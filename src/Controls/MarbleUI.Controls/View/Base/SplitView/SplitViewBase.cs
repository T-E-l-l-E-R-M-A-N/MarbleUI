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

        public static readonly StyledProperty<SplitPaneAlignment> PaneAlignmentProperty =
            AvaloniaProperty.Register<SplitViewBase, SplitPaneAlignment>("PaneAlignment");

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
            set => SetValue(SplitPaneIsVisibleProperty, value);
        }

        public SplitPaneAlignment PaneAlignment
        {
            get => GetValue(PaneAlignmentProperty);
            set => SetValue(PaneAlignmentProperty, value);
        }
        #endregion
        
        #region Protected Methods
        
        protected override void SetToolBarMargin(WindowState obj)
        {
            switch (_window.Content)
            {
                case ISplitView when obj is WindowState.Maximized or WindowState.Normal:
                {
                    if (PaneAlignment == SplitPaneAlignment.Left)
                    {
                        PART_ToolBarPresenter.Margin = Thickness.Parse(SplitPaneIsVisible ? "0,0,0,0" : "70,0,0,0");
                    }
                    else
                    {
                        PART_ToolBarPresenter.Margin = Thickness.Parse("70,0,0,0");
                    }

                    break;
                }
                case ISplitView:
                {
                    
                    if(obj is WindowState.FullScreen)
                    {
                        PART_ToolBarPresenter.Margin = Thickness.Parse("0,0,0,0");
                        
                    }
                    break;
                }
            }
        }

        #endregion
    }
}