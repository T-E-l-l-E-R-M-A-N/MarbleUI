using Avalonia.Controls.Generators;
using Avalonia.Controls.Presenters;

namespace MarbleUI.Controls
{
    public class MenuItemsPresenter : ItemsPresenter, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(MenuItemsPresenter);

        #endregion

        protected override IItemContainerGenerator CreateItemContainerGenerator()
        {
            return new ItemContainerGenerator<MenuItem>(this, MenuItem.ContentProperty, null);
        }

        #region Public Methods

        public void CallCreateItemContainerGeneratorMethod()
        {
            CreateItemContainerGenerator();
        }

        #endregion
    }
}