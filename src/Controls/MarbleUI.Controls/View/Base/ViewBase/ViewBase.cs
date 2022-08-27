using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;

namespace MarbleUI.Controls
{
    public abstract class ViewBase : ContentControl, IView
    {
        #region Public Fields

        public ContentPresenter PART_ToolBarPresenter;
        public Window _window;

        #endregion
        
        #region Avalonia Properties

        public static readonly StyledProperty<UIToolBar> ToolBarProperty =
            AvaloniaProperty.Register<ViewBase, UIToolBar>("ToolBar");

        #endregion

        #region Public Properties

        public UIToolBar ToolBar
        {
            get => GetValue(ToolBarProperty);
            set => SetValue(ToolBarProperty, value);
        }

        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _window = this.GetLogicalParent<Window>();

            _window.PlatformImpl.WindowStateChanged += WindowStateChanged;
            
            PART_ToolBarPresenter = e.NameScope.Find<ContentPresenter>(nameof(PART_ToolBarPresenter));
            
            _window.PlatformImpl.WindowStateChanged.Invoke( _window.PlatformImpl.WindowState);
        }

        #endregion

        #region Abstract Methods

        protected abstract void SetToolBarMargin(WindowState obj);

        #endregion

        #region Public Events Handlers
        
        public void WindowStateChanged(WindowState obj)
        {
            SetToolBarMargin(obj);
        }

        #endregion
    }
}