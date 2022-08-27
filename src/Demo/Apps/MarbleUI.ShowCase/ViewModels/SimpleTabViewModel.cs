using Prism.Commands;
using Prism.Mvvm;

namespace MarbleUI.ShowCase
{
    public class SimpleTabViewModel : BindableBase
    {
        private string _header;

        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                RaisePropertyChanged();
            }
        }

        public object? Content { get; set; }
        public DelegateCommand<SimpleTabViewModel> CloseCommand { get; set; }

        public SimpleTabViewModel(string header, object? content, DelegateCommand<SimpleTabViewModel> closeCommand)
        {
            Header = header;
            Content = content;
            CloseCommand = closeCommand;
        }
    }
}