using System.Collections.Specialized;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Templates;
using Avalonia.Controls.Utils;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Metadata;

namespace MarbleUI.Controls
{

    public class MenuContainer : ItemsControl, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(MenuContainer);

        #endregion

        private MenuItemsPresenter _itemsPr;

        #region Avalonia Properties

        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<MenuContainer, string>("Title");

        public static readonly StyledProperty<Orientation> OrientationProperty =
            AvaloniaProperty.Register<MenuContainer, Orientation>("Orientation");


        #endregion

        #region Public Properties
        public string Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Orientation Orientation
        {
            get => GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        #endregion

        #region Protected Methods

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _itemsPr = e.NameScope.Find<MenuItemsPresenter>("PART_ItemsPresenter");

            if (_itemsPr != null)
            {
                _itemsPr.CallCreateItemContainerGeneratorMethod();
            }
        }

        //protected override IItemContainerGenerator CreateItemContainerGenerator()
        //{
        //    return new ItemContainerGenerator<MenuItem>(this, MenuItem.ContentProperty, null);
        //}

        #endregion

    }
}
