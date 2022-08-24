using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Styling;

namespace MarbleUI.Controls
{
    public class UIWindow : Avalonia.Controls.Window, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIWindow);

        #endregion
        
        #region Private Fields

        private Border PART_BorderTitleBar;
        #endregion
    
        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            ExtendClientAreaToDecorationsHint = true;
            TransparencyLevelHint = WindowTransparencyLevel.Blur;
            MinHeight = 53;
            
            base.OnApplyTemplate(e);

            PART_BorderTitleBar = e.NameScope.Find<Border>(nameof(PART_BorderTitleBar));
            
            PART_BorderTitleBar.PointerPressed += PART_BorderTitleBarOnPointerPressed;
            PART_BorderTitleBar.DoubleTapped += PART_BorderTitleBarOnDoubleTapped;
        }

        #endregion

        #region Private Events Handlers
        
        private void PART_BorderTitleBarOnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (WindowState != WindowState.FullScreen)
            {
                BeginMoveDrag(e);
            }
        }
        
        private void PART_BorderTitleBarOnDoubleTapped(object? sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.FullScreen & e.Source == PART_BorderTitleBar)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
        }

        #endregion
    }
}