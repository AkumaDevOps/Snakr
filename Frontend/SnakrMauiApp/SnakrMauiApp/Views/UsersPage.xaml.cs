namespace SnakrMauiApp.Views;

public partial class UsersPage : ContentPage
{
	UsersViewModel ViewModel;

	public UsersPage(UsersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadDataAsync();
	}
}
