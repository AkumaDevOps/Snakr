namespace SnakrMauiApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(UsersDetailPage), typeof(UsersDetailPage));
	}
}
