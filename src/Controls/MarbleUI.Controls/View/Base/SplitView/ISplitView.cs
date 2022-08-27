using Avalonia.Controls;
using Avalonia.LogicalTree;

namespace MarbleUI.Controls
{
    public interface ISplitView : IView
    {
        double SplitPaneLength { get; set; }
        bool SplitPaneIsVisible { get; set; }
        Alignment PaneAlignment { get; set; }
    }
}