using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.VisualTree;
using MarbleUI.Controls;

namespace MarbleUI.Controls
{
    public class MenuItem : Button, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(MenuItem);

        #endregion

        #region Private Fields
        private IEnumerable _items = new AvaloniaList<object>();
        private MenuContainer? _menuContainer;
        private MenuItem? _menuItem;
        private Viewbox _iconItems;
        private Popup? _popup;
        private MenuItemsPresenter _itemsPr;
        #endregion

        #region Avalonia Proeprties
        /// <summary>
        /// Defines the <see cref="Items"/> property.
        /// </summary>
        public static readonly DirectProperty<MenuItem, IEnumerable> ItemsProperty =
            AvaloniaProperty.RegisterDirect<MenuItem, IEnumerable>(nameof(Items), o => o.Items, (o, v) => o.Items = v);

        public static readonly StyledProperty<bool> IsHighlightedProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsHighlighted");

        public static readonly StyledProperty<bool> IsMenuOpenProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsMenuOpen");

        public static readonly StyledProperty<bool> IsCheckedProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsChecked");

        public static readonly StyledProperty<bool> IsCheckableProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsCheckable");

        public static readonly StyledProperty<string> GroupProperty =
            AvaloniaProperty.Register<MenuItem, string>("Group");

        public static readonly StyledProperty<bool> IsRadioButtonModeProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsRadioButtonMode");

        public static readonly StyledProperty<bool> IsHasItemsProperty =
            AvaloniaProperty.Register<MenuItem, bool>("IsHasItems");

        

        #endregion

        #region Public Proeprties
        public IEnumerable Items
        {
            get => _items;
            set => SetAndRaise(ItemsProperty, ref _items, value);
        }
        public bool IsHighlighted
        {
            get => GetValue(IsHighlightedProperty);
            set => SetValue(IsHighlightedProperty, value);
        }
        public bool IsMenuOpen
        {
            get => GetValue(IsMenuOpenProperty);
            set => SetValue(IsMenuOpenProperty, value);
        }
        public bool IsChecked
        {
            get => GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }
        public bool IsCheckable
        {
            get => GetValue(IsCheckableProperty);
            set => SetValue(IsCheckableProperty, value);
        }
        public string Group
        {
            get => GetValue(GroupProperty);
            set => SetValue(GroupProperty, value);
        }
        public bool IsRadioButtonMode
        {
            get => GetValue(IsRadioButtonModeProperty);
            set => SetValue(IsRadioButtonModeProperty, value);
        }
        public bool IsHasItems
        {
            get => GetValue(IsHasItemsProperty);
            set => SetValue(IsHasItemsProperty, value);
        }
        #endregion

        #region Protected Methods
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _menuContainer = this.Parent as MenuContainer;
            _menuItem = TryGetParentMenuItemByStyleHost(this);

            _itemsPr = e.NameScope.Find<MenuItemsPresenter>("PART_ItemsPresenter");

            _iconItems = e.NameScope.Find<Viewbox>("PART_ListItemsIcon");

            if (_itemsPr != null) _itemsPr.CallCreateItemContainerGeneratorMethod();

            if (Items != null)
            {
                IsHasItems = true;
            }
            else
            {
                IsHasItems = false;
            }

            _popup = e.NameScope.Find<Popup>("PART_Popup");
            _popup.PointerEnter += _popup_PointerEnter;

            if (IsCheckable)
            {
                Command = null;
                CommandParameter = null;
            }
        }
        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);
            if(_menuContainer == null)
            {
                IsHighlighted = false;
            }
            var mi = this.GetVisualParent<MenuItem>();
            if(mi != null)
            {
                foreach (var item in mi.Items)
                {
                    if (item != this)
                    {
                        IsMenuOpen = true;
                        _popup.IsOpen = IsMenuOpen;
                    }
                }
            }
            
        }
        protected override void OnPointerEnter(PointerEventArgs e)
        {
            base.OnPointerEnter(e);

            if(e.Source is MenuItem && Parent != _menuContainer)
            {
                IsHighlighted = true;
                try
                {
                    if (Items.OfType<object>().Count() == 0)
                    {
                        if (_popup != null)
                        {
                            IsMenuOpen = false;
                            _popup.IsOpen = IsMenuOpen;
                        }
                    }
                    else
                    {
                        if (_popup != null)
                        {
                            IsMenuOpen = true;
                            _popup.IsOpen = IsMenuOpen;
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {

            }

        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            if (_menuContainer != null)
            {
                if (Items != null)
                {
                    if (Items.OfType<object>().Any())
                    {
                        if (_popup != null)
                        {
                            IsMenuOpen = true;
                            _popup.IsOpen = IsMenuOpen;
                        }
                    }
                }
                IsHighlighted = true;
            }

            if (IsCheckable)
            {
                IsChecked = !IsChecked;
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);


            IsHighlighted = false;
            if (_popup != null)
            {
                IsMenuOpen = false;
                _popup.IsOpen = IsMenuOpen;
            }
        }
        #endregion

        #region Private Events Handlers

        private void _popup_PointerEnter(object? sender, PointerEventArgs e)
        {
            var mi = this.GetVisualParent<MenuItem>();
            if (mi != null) mi.IsHighlighted = true;
        }
        #endregion

        #region Private Events
        private MenuItem TryGetParentMenuItemByStyleHost(IStyleHost visual)
        {
            if(visual != null)
            {
                if (visual.StylingParent is MenuItem m)
                {
                    return m;
                }
            }
            else
            {
                return null;
            }

            return TryGetParentMenuItemByStyleHost(visual.StylingParent);
        }

        private MenuItem TryGetParentMenuItemByInteractive(IInteractive interactive)
        {
            if (interactive != null)
            {
                if (interactive.InteractiveParent is MenuItem m)
                {
                    return m;
                }
            }
            else
            {
                return null;
            }

            return TryGetParentMenuItemByInteractive(interactive.InteractiveParent);
        }
        #endregion
    }
}
