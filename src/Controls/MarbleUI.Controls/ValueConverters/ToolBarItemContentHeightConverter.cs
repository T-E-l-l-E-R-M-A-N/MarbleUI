using System.Dynamic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace MarbleUI.Controls
{
    public class ToolBarItemContentHeightConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double height = 30;
            if (value is UIToolBar tb)
            {
                if (tb.ToolBarMode == UIToolBarMode.OnlyIcon)
                {
                    return height;
                }
                else if (tb.ToolBarMode == UIToolBarMode.BothTextAndLabel)
                {
                    height = 24;
                    return height;
                }
            }
            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}