using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;

namespace MarbleUI.Controls
{
    public class UICaptionButtons : TemplatedControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UICaptionButtons);

        #endregion

        #region Private Fields

        private Window _window;
        
        private Button PART_CloseButton;
        private Button PART_MinimiseButton;
        private Button PART_FullScrButton;
        private WindowState _winState;

        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _window = this.FindAncestorOfType<Window>();

            PART_CloseButton = e.NameScope.Find<Button>(nameof(PART_CloseButton));
            PART_MinimiseButton = e.NameScope.Find<Button>(nameof(PART_MinimiseButton));
            PART_FullScrButton = e.NameScope.Find<Button>(nameof(PART_FullScrButton));

            
            PART_CloseButton.Click += PART_CloseButtonOnClick;
            PART_MinimiseButton.Click += PART_MinimiseButtonOnClick;
            PART_FullScrButton.Click += PART_FullScrButtonOnClick;
        }

        #endregion

        #region Private Events Handlers
        private void PART_CloseButtonOnClick(object? sender, RoutedEventArgs e)
        {
            _window.Close(); 
        }
        private void PART_MinimiseButtonOnClick(object? sender, RoutedEventArgs e)
        {
            _window.PlatformImpl.WindowState = WindowState.Minimized;
        }
        private void PART_FullScrButtonOnClick(object? sender, RoutedEventArgs e)
        {
            //_window.PlatformImpl.WindowStateChanged += WindowStateChanged;
            //_window.PlatformImpl.SetExtendClientAreaChromeHints(ExtendClientAreaChromeHints.SystemChrome);
            if (_window.WindowState is WindowState.Maximized or WindowState.Normal)
            {
                _winState = _window.WindowState;
                _window.WindowState = WindowState.FullScreen;
                _window.PlatformImpl.WindowStateChanged += WindowStateChanged;
                PART_MinimiseButton.IsEnabled = false;
                PART_MinimiseButton.Opacity = 0;
                PointerEnter += OnPointerEnter;
                PointerLeave += OnPointerLeave;
                Opacity = 0;
            }
            else if(_window.WindowState is WindowState.FullScreen)
            {
                _window.PlatformImpl.WindowState = _winState;
                PART_MinimiseButton.IsEnabled = true;
                _window.PlatformImpl.WindowStateChanged?.Invoke(_window.PlatformImpl.WindowState);
            }

            //this.IsVisible = false;
        }

        private void OnPointerLeave(object? sender, PointerEventArgs e)
        {
            if (_window.WindowState == WindowState.FullScreen)
            {
                Opacity = 0;
            }
        }

        private void OnPointerEnter(object? sender, PointerEventArgs e)
        {
            if (_window.WindowState == WindowState.FullScreen)
            {
                Opacity = 1;
            }
        }

        private void WindowStateChanged(WindowState obj)
        {
            if (obj is WindowState.Maximized or WindowState.Normal)
            {
                Opacity = 1;
                PART_MinimiseButton.Opacity = 1;
                PointerEnter -= OnPointerEnter;
                PointerLeave -= OnPointerLeave;
                _window.PlatformImpl.SetExtendClientAreaChromeHints(ExtendClientAreaChromeHints.NoChrome);
                _window.PlatformImpl.WindowStateChanged -= WindowStateChanged;
            }
        }

        #endregion
    }
}