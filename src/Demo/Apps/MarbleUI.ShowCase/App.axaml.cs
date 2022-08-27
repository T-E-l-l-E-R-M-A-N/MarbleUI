using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PropertyChanged;

namespace MarbleUI.ShowCase
{
    [DoNotNotify]
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var vm = new MainViewModel(new ActionSheetServiceImpl());
                var win = new MainUiWindow();
                win.DataContext = vm;
                desktop.MainWindow = win;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}