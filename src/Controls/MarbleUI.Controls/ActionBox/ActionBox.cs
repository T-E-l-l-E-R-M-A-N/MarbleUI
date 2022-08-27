using Avalonia.Controls;
using Avalonia.Input;
using MarbleUI.Controls.Services;

namespace MarbleUI.Controls
{
    public class ActionBox : Window, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(ActionBox);

        #endregion

        #region Public Fields

        public Button PART_RefuseButton;
        public Button PART_IgnoreButton;
        public Button PART_AcceptButton;
        public Button PART_RetryButton;
        public Button PART_CloseButton;
        
        private Border PART_BorderTitleBar;

        #endregion

        
        #region Avalonia Properties

        public static readonly StyledProperty<ActionSheetBoxButtons> ActionSheetBoxButtonsProperty =
            AvaloniaProperty.Register<ActionBox, ActionSheetBoxButtons>("ActionSheetBoxButtons");

        public static readonly StyledProperty<ActionSheetResult> ActionSheetBoxResultProperty =
            AvaloniaProperty.Register<ActionBox, ActionSheetResult>("ActionSheetBoxResult");

        public static readonly StyledProperty<ActionSheetBoxDefaultButtonKey> ActionSheetBoxDefaultButtonKeyProperty =
            AvaloniaProperty.Register<ActionBox, ActionSheetBoxDefaultButtonKey>("ActionSheetBoxDefaultButtonKey");

        #endregion

        #region Public Properties

        public bool WasClosed { get; set; }

        public ActionSheetResult ActionSheetBoxResult
        {
            get => GetValue(ActionSheetBoxResultProperty);
            set => SetValue(ActionSheetBoxResultProperty, value);
        }

        public ActionSheetBoxButtons ActionSheetBoxButtons
        {
            get => GetValue(ActionSheetBoxButtonsProperty);
            set => SetValue(ActionSheetBoxButtonsProperty, value);
        }
        
        public ActionSheetBoxDefaultButtonKey ActionSheetBoxDefaultButtonKey
        {
            get => GetValue(ActionSheetBoxDefaultButtonKeyProperty);
            set => SetValue(ActionSheetBoxDefaultButtonKeyProperty, value);
        }

        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            ExtendClientAreaToDecorationsHint = true;
            TransparencyLevelHint = WindowTransparencyLevel.Blur;
            
            base.OnApplyTemplate(e);

            PART_CloseButton = e.NameScope.Find<Button>(nameof(PART_CloseButton));
            PART_RefuseButton = e.NameScope.Find<Button>(nameof(PART_RefuseButton));
            PART_AcceptButton = e.NameScope.Find<Button>(nameof(PART_AcceptButton));
            PART_RetryButton = e.NameScope.Find<Button>(nameof(PART_RetryButton));
            PART_IgnoreButton = e.NameScope.Find<Button>(nameof(PART_IgnoreButton));
            
            PART_BorderTitleBar = e.NameScope.Find<Border>(nameof(PART_BorderTitleBar));
            
            PART_BorderTitleBar.PointerPressed += PART_BorderTitleBarOnPointerPressed;
            PART_BorderTitleBar.DoubleTapped += PART_BorderTitleBarOnDoubleTapped;
            
            PART_CloseButton.Click += (sender, args) =>
            {
                ActionSheetBoxResult = ActionSheetResult.ResultNone;
                Close();
            };
            if (PART_RetryButton != null)
                PART_RetryButton.Click += (sender, args) =>
                {
                    ActionSheetBoxResult = ActionSheetResult.ResultRetry;  
                    Close();
                };
            if (PART_RefuseButton != null)
                PART_RefuseButton.Click += (sender, args) =>
                {
                    ActionSheetBoxResult = ActionSheetResult.ResultCancel;
                    Close();
                };
            if (PART_IgnoreButton != null)
                PART_IgnoreButton.Click += (sender, args) =>
                {
                    ActionSheetBoxResult = ActionSheetResult.ResultIgnore;
                    Close();
                };
            if (PART_AcceptButton != null)
                PART_AcceptButton.Click += (sender, args) =>
                {
                    ActionSheetBoxResult = ActionSheetResult.ResultOK;
                    Close();
                };

            WasClosed = false;
            Closed += OnClosed;
        }

        #endregion
        
        #region Private Events Handlers

        private void OnClosed(object? sender, EventArgs e)
        {
            WasClosed = true;
        }
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