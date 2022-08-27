using Avalonia.Controls.Templates;

namespace MarbleUI.Controls
{
    public class TabView : ViewBase, IStyleable
    {
        #region IStyleable

        Type IStyleable.StyleKey => typeof(TabView);

        #endregion

        #region Private Fields

        private IEnumerable? _items = new AvaloniaList<object>();

        #endregion
        
        #region Avalonia Properties
        /// <summary>
        /// Defines the <see cref="Items"/> property.
        /// </summary>
        public static readonly DirectProperty<TabView, IEnumerable?> ItemsProperty = 
            AvaloniaProperty.RegisterDirect<TabView, IEnumerable?>(nameof(Items), o => o.Items, (o, v) => o.Items = v);
        
        public static readonly StyledProperty<bool> TabStripIsVisibleProperty =
            AvaloniaProperty.Register<TabView, bool>("TabStripIsVisible");

        public static readonly StyledProperty<IDataTemplate> ItemHeaderTemplateProperty =
            AvaloniaProperty.Register<TabView, IDataTemplate>("ItemHeaderTemplate");

        public static readonly StyledProperty<Alignment> ItemStripAlignmentProperty =
            AvaloniaProperty.Register<TabView, Alignment>("ItemStripAlignment");
        
        
        #endregion

        #region Public Properties

        public IEnumerable? Items
        {
            get => _items;
            set => SetAndRaise(ItemsProperty, ref _items, value);
        }

        public bool TabStripIsVisible
        {
            get => GetValue(TabStripIsVisibleProperty);
            set => SetValue(TabStripIsVisibleProperty, value);
        }

        public IDataTemplate ItemHeaderTemplate
        {
            get => GetValue(ItemHeaderTemplateProperty);
            set => SetValue(ItemHeaderTemplateProperty, value);
        }

        public Alignment ItemStripAlignment
        {
            get => GetValue(ItemStripAlignmentProperty);
            set => SetValue(ItemStripAlignmentProperty, value);
        }
        #endregion
    }
}