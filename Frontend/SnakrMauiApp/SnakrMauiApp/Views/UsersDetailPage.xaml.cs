namespace SnakrMauiApp.Views;

public partial class UsersDetailPage : ContentPage
{
	public UsersDetailPage(MasterUsersDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
