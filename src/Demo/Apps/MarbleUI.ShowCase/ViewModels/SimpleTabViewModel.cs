using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    public class SimpleTabViewModel : BindableBase
    {
        public string Header { get; set; }
        public object? Content { get; set; }

        public SimpleTabViewModel(string header, object? content)
        {
            Header = header;
            Content = content;
        }
    }
}