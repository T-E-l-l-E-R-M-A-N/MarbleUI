using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Templates;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml.Templates;

namespace MarbleUI.Controls
{
    public class TabView : ListBox, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(TabView);

        #endregion

        #region Public Fields

        public ContentPresenter PART_ToolBarPresenter;
        public Window _window;

        #endregion
        
        #region Avalonia Properties

        public static readonly StyledProperty<IDataTemplate?> ContentTemplateProperty =
            ContentControl.ContentTemplateProperty.AddOwner<TabView>();

        public static readonly StyledProperty<Alignment> ItemStripAlignmentProperty =
            AvaloniaProperty.Register<TabView, Alignment>("ItemStripAlignment");

        public static readonly StyledProperty<bool> TabStripIsVisibleProperty =
            AvaloniaProperty.Register<TabView, bool>("TabStripIsVisible");

        public static readonly StyledProperty<UIToolBar> ToolBarProperty =
            AvaloniaProperty.Register<TabView, UIToolBar>("ToolBar");

        #endregion

        #region Public Properties

        public UIToolBar ToolBar
        {
            get => GetValue(ToolBarProperty);
            set => SetValue(ToolBarProperty, value);
        }

        public Alignment ItemStripAlignment
        {
            get => GetValue(ItemStripAlignmentProperty);
            set => SetValue(ItemStripAlignmentProperty, value);
        }

        public bool TabStripIsVisible
        {
            get => GetValue(TabStripIsVisibleProperty);
            set => SetValue(TabStripIsVisibleProperty, value);
        }
        
        /// <summary>
        /// Gets or sets the data template used to display the content of the control.
        /// </summary>
        public IDataTemplate? ContentTemplate
        {
            get { return GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }
        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _window = this.GetLogicalParent<Window>();

            if (_window != null)
            {
            
                PART_ToolBarPresenter = e.NameScope.Find<ContentPresenter>(nameof(PART_ToolBarPresenter));
            
                _window.PlatformImpl.WindowStateChanged.Invoke( _window.PlatformImpl.WindowState);
            }
        }

        #endregion

        #region Abstract Methods

        #endregion

        #region Public Events Handlers

        #endregion
    }
}