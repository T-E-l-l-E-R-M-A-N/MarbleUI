using Avalonia.Input;
using MarbleUI.Controls.Services;

namespace MarbleUI.Controls
{
    public class ActionSheet : ContentControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(ActionSheet);

        #endregion

        #region Avalonia Properties

        public static readonly StyledProperty<IActionSheetService> ActionSheetServiceProperty =
            AvaloniaProperty.Register<ActionSheet, IActionSheetService>("ActionSheetService");

        #endregion

        #region Public Properties

        public IActionSheetService ActionSheetService
        {
            get => GetValue(ActionSheetServiceProperty);
            set => SetValue(ActionSheetServiceProperty, value);
        }

        #endregion

        #region Protected Methods

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Escape)
            {
                ActionSheetService.SheetShow = false;
            }
        }

        #endregion
    }
}