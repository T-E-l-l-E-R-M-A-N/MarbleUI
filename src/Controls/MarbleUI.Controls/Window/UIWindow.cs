using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Styling;
using Avalonia.VisualTree;

namespace MarbleUI.Controls
{
    public class UIWindow : Avalonia.Controls.Window, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(UIWindow);

        #endregion
        
        #region Private Fields

        private Border PART_BorderTitleBar;
        private UICaptionButtons _captionButtons;
        private ViewBase _view;

        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            ExtendClientAreaToDecorationsHint = true;
            TransparencyLevelHint = WindowTransparencyLevel.None;
            MinHeight = 53;
            
            base.OnApplyTemplate(e);

            PART_BorderTitleBar = e.NameScope.Find<Border>(nameof(PART_BorderTitleBar));
            
            PART_BorderTitleBar.PointerPressed += PART_BorderTitleBarOnPointerPressed;
            PART_BorderTitleBar.DoubleTapped += PART_BorderTitleBarOnDoubleTapped;

            _captionButtons = GetChildrenUICapButtons(this.VisualChildren);
            _captionButtons._titleBarPlaceHolder = PART_BorderTitleBar;

            _view = GetChildrenView(this.LogicalChildren);
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
        
        #region Private Methods

        private UICaptionButtons GetChildrenUICapButtons(IReadOnlyList<IVisual> child)
        {
            foreach (var obj in child)
            {
                GetChildrenUICapButtons(obj.VisualChildren);
                if (obj is UICaptionButtons c)
                {
                    _captionButtons = c;
                    return _captionButtons;
                }
            }

            return _captionButtons == null ? new UICaptionButtons() : _captionButtons;
        }

        private ViewBase GetChildrenView(IReadOnlyList<ILogical> child)
        {
            foreach (var obj in child)
            {
                GetChildrenView(obj.LogicalChildren);
                if (obj is ViewBase c)
                {
                    _view = c;
                    return _view;
                }
            }

            return _view == null ? null : _view;
        }
        #endregion
    }
}