using System.Windows.Input;

namespace Module02Exercise01.View;

public partial class OfflinePage : ContentPage
{
	public OfflinePage()
	{
        InitializeComponent();
        BindingContext = new OfflineViewModel();
    }
}

public class OfflineViewModel
{
    public ICommand RetryCommand { get; }
    public ICommand CloseCommand { get; }

    public OfflineViewModel()
    {
        RetryCommand = new Command(() => Application.Current.MainPage = new AppShell());
        CloseCommand = new Command(() => System.Diagnostics.Process.GetCurrentProcess().Kill());
    }
}
